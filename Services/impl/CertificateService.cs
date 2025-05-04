using Hoangnhhe171693.DB;
using Hoangnhhe171693.Mapper;
using Hoangnhhe171693.Models;
using Hoangnhhe171693.Models.DTO.Request.Certificate;
using Hoangnhhe171693.Models.DTO.Response;
using Hoangnhhe171693.Utility;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Hoangnhhe171693.Services.impl;

public class CertificateService : ICertificateService
{
    private readonly ApplicationDbContext _context;
    private readonly ICertificateMapper _mapper;
    private readonly Validation<Certificate> _validation;

    public CertificateService(ApplicationDbContext context, ICertificateMapper mapper, Validation<Certificate> validation)
    {
        _context = context;
        _mapper = mapper;
        _validation = validation;
    }
    public async Task<CertificateResponse> CreateCertificateAsync(CertificateCreate create)
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

        if (await _context.Certificates.AnyAsync(x => x.Name == create.Name))
        {
            throw new Exception($"Tên chứng chỉ {create.Name} đã tồn tại");
        }
        Certificate entity = _mapper.CreateToEntity(create);

        await _context.Certificates.AddAsync(entity);
        await _context.SaveChangesAsync();
        var response = _mapper.EntityToResponse(entity);
        return response;
    }

    public async Task<CertificateResponse> FindCertificateByIdAsync(int id)
    {
        var tId = await _context.Certificates.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có chứng chỉ nào với Id {id}");
        var response = _mapper.EntityToResponse(tId);
        return response;
    }

    public async Task<IEnumerable<CertificateResponse>> GetAllCertificatesAsync()
    {
        var tId = await _context.Certificates.ToListAsync();
        if (tId == null) throw new Exception($"Không có chứng chỉ nào");
        var response = _mapper.ListEntityToResponse(tId);
        return response;
    }

    public async Task<bool> HardDeleteCertificateAsync(int id)
    {
        var tId = await _context.Certificates.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có chứng chỉ nào với Id {id}");

        _context.Certificates.Remove(tId);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<CertificateResponse>> SearchCertificateByKeyAsync(string key)
    {
        var tkey = await _context.Certificates
               .FromSqlRaw("Select * from Certificate where Name like {0}", "%" + key + "%").ToListAsync();

        if (tkey == null) throw new Exception($"không có {key} nào");
        var response = _mapper.ListEntityToResponse(tkey);
        return response;
    }

    public async Task<CertificateResponse> SoftDeleteCertificateAsync(int id, Status.CertificateD newStatus)
    {
        var tId = await _context.Certificates.FindAsync(id);
        if (tId == null) throw new Exception($"không có Id {id} tồn tại");

        tId.Status = newStatus;
        await _context.SaveChangesAsync();
        var response = _mapper.EntityToResponse(tId);
        return response;
    }

    public async Task<CertificateResponse> UpdateCertificateAsync(int id, CertificateUpdate update)
    {
        var tId = await _context.Certificates.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có chứng chỉ nào chứa {id}");

        tId.Name = await _validation.CheckAndUpdateAPIAsync(tId, tId.Name, update.Name, t => t.Name == update.Name);
        tId.Description = await _validation.CheckAndUpdateAPIAsync(tId, tId.Description, update.Description, t => t.Description == update.Description);
        //tId.IdTinh = await _validation.CheckAndUpdateQuantityAsync(tId, tId.IdTinh, update.IdTinh, co => co.IdTinh == update.IdTinh);
        
        var result = _mapper.UpdateToEntity(update);
        tId.IdTinh = result.IdTinh;
        tId.Status = result.Status;

        await _context.SaveChangesAsync();

        var response = _mapper.EntityToResponse(tId);
        return response;
    }
}
