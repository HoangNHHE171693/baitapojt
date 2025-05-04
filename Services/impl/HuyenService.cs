using BaiTapOceanTech.DB;
using BaiTapOceanTech.Mapper;
using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Huyen;
using BaiTapOceanTech.Models.DTO.Response;
using BaiTapOceanTech.Utility;
using BaiTapOceanTech.Utility;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BaiTapOceanTech.Services.impl;

public class HuyenService : IHuyenService
{
    private readonly ApplicationDbContext _context;
    private readonly IHuyenMapper _mapper;
    private readonly Validation<Huyen> _validation;

    public HuyenService(ApplicationDbContext context, IHuyenMapper mapper, Validation<Huyen> validation)
    {
        _context = context;
        _mapper = mapper;
        _validation = validation;
    }
    public async Task<HuyenResponse> CreateHuyenAsync(HuyenCreate create)
    {
        
        if (string.IsNullOrEmpty(create.Name))
        {
            throw new Exception("Không được để trống tên");
        }
        create.Name = Regex.Replace(create.Name.Trim(), @"\s+", " ");
        if (!Regex.IsMatch(create.Name, @"^[a-zA-ZÀ-Ỹà-ỹ\s]+$"))
        {
            throw new Exception("Tên không được chứa kí tự đặc biệt");
        }
        if (await _context.Huyen.AnyAsync(x => x.Name == create.Name))
        {
            throw new Exception($"Tên Huyện {create.Name} đã tồn tại");
        }
        Huyen entity = _mapper.CreateToEntity(create);
        await _context.Huyen.AddAsync(entity);
        await _context.SaveChangesAsync();
        var response = _mapper.EntityToResponse(entity);
        return response;
    }

    public async Task<HuyenResponse> FindHuyenByIdAsync(int id)
    {
        var tId = await _context.Huyen.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có huyện nào chứa Id {id}");
        var response = _mapper.EntityToResponse(tId);
        return response;
    }

    public async Task<IEnumerable<HuyenResponse>> GetAllHuyensAsync()
    {
        var tId = await _context.Huyen.ToListAsync();
        if (tId == null) throw new Exception($"Không có huyện nào");
        var response = _mapper.ListEntityToResponse(tId);
        return response;
    }

    public async Task<IEnumerable<HuyenResponse>> getHuyenByIdTinhAsync(int id)
    {
        var huyens = await _context.Huyen.Where(h => h.IdTinh == id).ToListAsync();
        if (!huyens.Any())
        {
            throw new Exception($"Không có huyện nào thuộc tỉnh có Id {id}");
        }

        var response = _mapper.ListEntityToResponse(huyens);
        return response;
    }

    public async Task<bool> HardDeleteHuyenAsync(int id)
    {
        var tId = await _context.Huyen.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có huyện nào chứa Id {id}");

        _context.Huyen.Remove(tId);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<HuyenResponse>> SearchHuyenByKeyAsync(string key)
    {
        var tkey = await _context.Huyen
               .FromSqlRaw("Select * from Huyen where Name like {0}", "%" + key + "%").ToListAsync();

        if (tkey == null) throw new Exception($"không có huyện tên {key} nào");
        var response = _mapper.ListEntityToResponse(tkey);
        return response;
    }

    public async Task<HuyenResponse> SoftDeleteHuyenAsync(int id, Status.Statuss newStatus)
    {
        var tId = await _context.Huyen.FindAsync(id);
        if (tId == null) throw new Exception($"Không có Id {id} tồn tại");

        tId.Status = newStatus;
        await _context.SaveChangesAsync();
        var response = _mapper.EntityToResponse(tId);
        return response;
    }

    public async Task<HuyenResponse> UpdateHuyenAsync(int id, HuyenUpdate update)
    {
        var tId = await _context.Huyen.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có huyện nào chứa Id {id}");

        tId.PostalCode = await _validation.CheckAndUpdateAPIAsync(tId, tId.PostalCode, update.PostalCode, t => t.PostalCode == update.PostalCode);
        tId.Name = await _validation.CheckAndUpdateAPIAsync(tId, tId.Name, update.Name, t => t.Name == update.Name);
        tId.CreatedDate = await _validation.CheckAndUpdateDate2Async(tId, tId.CreatedDate, update.CreatedDate);
        tId.UpdatedDate = await _validation.CheckAndUpdateDate2Async(tId, tId.UpdatedDate, update.UpdatedDate);

        var result = _mapper.UpdateToEntity(update);

        tId.IdTinh = result.IdTinh;
        tId.Status = result.Status;

        await _context.SaveChangesAsync();

        var response = _mapper.EntityToResponse(tId);
        return response;
    }
}
