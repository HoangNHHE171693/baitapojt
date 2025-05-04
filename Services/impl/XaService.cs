using BaiTapOceanTech.DB;
using BaiTapOceanTech.Mapper;
using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Xa;
using BaiTapOceanTech.Models.DTO.Response;
using BaiTapOceanTech.Utility;
using BaiTapOceanTech.Utility;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BaiTapOceanTech.Services.impl;

public class XaService : IXaService
{
    private readonly ApplicationDbContext _context;
    private readonly IXaMapper _mapper;
    private readonly Validation<Xa> _validation;

    public XaService(ApplicationDbContext context, IXaMapper mapper, Validation<Xa> validation)
    {
        _context = context;
        _mapper = mapper;
        _validation = validation;
    }
    public async Task<XaResponse> CreateXaAsync(XaCreate create)
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
        if (await _context.Xas.AnyAsync(x => x.Name == create.Name))
        {
            throw new Exception($"Tên Xã {create.Name} đã tồn tại");
        }
        Xa entity = _mapper.CreateToEntity(create);
        await _context.Xas.AddAsync(entity);
        await _context.SaveChangesAsync();
        var response = _mapper.EntityToResponse(entity);
        return response;
    }

    public async Task<XaResponse> FindXaByIdAsync(int id)
    {
        var tId = await _context.Xas.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null)
        {
            throw new Exception($"Không có xã nào chứa Id {id}");
        }
        var response = _mapper.EntityToResponse(tId);
        return response;
      }

    public async Task<IEnumerable<XaResponse>> FindXaByIdHuyenAsync(int id)
    {
        var xas = await _context.Xas.Where(x => x.IdHuyen == id).ToListAsync();

        if (!xas.Any()) throw new Exception($"Không có Xã nào thuộc huyện có Id {id}");

        var response = _mapper.ListEntityToResponse(xas);
        return response;
    }

    public async Task<IEnumerable<XaResponse>> GetAllXasAsync()
    {
        var tId = await _context.Xas.ToListAsync();
        if (tId == null) throw new Exception($"Không có xã nào");
        var response = _mapper.ListEntityToResponse(tId);
        return response;
    }

    public async  Task<bool> HardDeleteXaAsync(int id)
    {
        var tId = await _context.Xas.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có xã nào chứa Id {id}");

        _context.Xas.Remove(tId);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<XaResponse>> SearchXaByKeyAsync(string key)
    {
        var tkey = await _context.Xas
               .FromSqlRaw("Select * from Xa where Name like {0}", "%" + key + "%").ToListAsync();

        if (tkey == null) throw new Exception($"Không có xã nào tên {key}");
        var response = _mapper.ListEntityToResponse(tkey);
        return response;
    }

    public async Task<XaResponse> SoftDeleteXaAsync(int id, Status.Statuss newStatus)
    {
        var tId = await _context.Xas.FindAsync(id);
        if (tId == null) throw new Exception($"Không có xã nào chứa Id {id}");

        tId.Status = newStatus;
        await _context.SaveChangesAsync();
        var response = _mapper.EntityToResponse(tId);
        return response;
    }

    public async Task<XaResponse> UpdateXaAsync(int id, XaUpdate update)
    {
        var tId = await _context.Xas.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có xã nào chứa Id {id}");

        tId.PostalCode = await _validation.CheckAndUpdateAPIAsync(tId, tId.PostalCode, update.PostalCode, t => t.PostalCode == update.PostalCode);
        tId.Name = await _validation.CheckAndUpdateAPIAsync(tId, tId.Name, update.Name, t => t.Name == update.Name);
        tId.CreatedDate = await _validation.CheckAndUpdateDate2Async(tId, tId.CreatedDate, update.CreatedDate);
        tId.UpdatedDate = await _validation.CheckAndUpdateDate2Async(tId, tId.UpdatedDate, update.UpdatedDate);

        var result = _mapper.UpdateToEntity(update);
        tId.IdHuyen = result.IdHuyen;
        tId.Status = result.Status;

        await _context.SaveChangesAsync();

        var response = _mapper.EntityToResponse(tId);
        return response;
    }
}
