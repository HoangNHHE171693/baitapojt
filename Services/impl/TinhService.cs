using BaiTapOceanTech.DB;
using BaiTapOceanTech.Mapper;
using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Tinh;
using BaiTapOceanTech.Models.DTO.Response;
using BaiTapOceanTech.Utility;

using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BaiTapOceanTech.Services.impl;

public class TinhService : ITinhService
{
    private readonly ApplicationDbContext _context;
    private readonly ITinhMapper _mapper;
    private readonly Validation<Tinh> _validation;

    public TinhService(ApplicationDbContext context, ITinhMapper mapper, Validation<Tinh> validation)
    {
        _context = context;
        _mapper = mapper;
        _validation = validation;
    }

    public async Task<TinhResponse> CreateTinhAsync(TinhCreate create)
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
        if (await _context.Tinh.AnyAsync(x => x.Name == create.Name))
        {
            throw new Exception($"Tên Tỉnh {create.Name} đã tồn tại");
        }
        Tinh entity = _mapper.CreateToEntity(create);
        await _context.Tinh.AddAsync(entity);
        await _context.SaveChangesAsync();
        var response = _mapper.EntityToResponse(entity);
        return response;
    }

    public async Task<TinhResponse> FindTinhByIdAsync(int id)
    {
        var tId = await _context.Tinh.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có tỉnh nào chứa Id {id}");
        var response = _mapper.EntityToResponse(tId);
        return response;
    }

    public async Task<IEnumerable<TinhResponse>> GetAllTinhsAsync()
    {
        var tId = await _context.Tinh.ToListAsync();
        if (tId == null) throw new Exception($"Không có tỉnh nào");
        var response = _mapper.ListEntityToResponse(tId);
        return response;
    }

    public async Task<bool> HardDeleteTinhAsync(int id)
    {
        var tId = await _context.Tinh.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có tỉnh nào chứa Id {id}");

        _context.Tinh.Remove(tId);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<TinhResponse>> SearchTinhByKeyAsync(string key)
    {
        var tkey = await _context.Tinh
               .FromSqlRaw("Select * from Tinh where Name like {0}", "%" + key + "%").ToListAsync();

        if (tkey == null) throw new Exception($"Không có tỉnh nào tên {key}");
        var response = _mapper.ListEntityToResponse(tkey);
        return response;
    }

    public async Task<TinhResponse> SoftDeleteTinhAsync(int id, Status.Statuss newStatus)
    {
        var tId = await _context.Tinh.FindAsync(id);
        if (tId == null) throw new Exception($"Không có tỉnh nào chứa Id {id}");

        tId.Status = newStatus;
        await _context.SaveChangesAsync();
        var response = _mapper.EntityToResponse(tId);
        return response;
    }


    public async Task<TinhResponse> UpdateTinhAsync(int id, TinhUpdate update)
    {
        var tId = await _context.Tinh.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có tỉnh nào chứa Id {id}");

        tId.PostalCode = await _validation.CheckAndUpdateAPIAsync(tId, tId.PostalCode, update.PostalCode, t => t.PostalCode == update.PostalCode);
        tId.Name = await _validation.CheckAndUpdateAPIAsync(tId, tId.Name, update.Name, t => t.Name == update.Name);
        tId.CreatedDate = await _validation.CheckAndUpdateDate2Async(tId, tId.CreatedDate, update.CreatedDate);
        tId.UpdatedDate = await _validation.CheckAndUpdateDate2Async(tId, tId.UpdatedDate, update.UpdatedDate);

        var result = _mapper.UpdateToEntity(update);

        
        tId.Status = result.Status;

        await _context.SaveChangesAsync();

        var response = _mapper.EntityToResponse(tId);
        return response;
    }
}
