using BaiTapOceanTech.DB;
using BaiTapOceanTech.Mapper;
using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.EmployeeCertificate;
using BaiTapOceanTech.Models.DTO.Response;
using BaiTapOceanTech.Utility;
using Microsoft.EntityFrameworkCore;
using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Services.impl;

public class EmployeeCertificateService : IEmployeeCertificateService
{
    private readonly ApplicationDbContext _context;
    private readonly IEmployeeCertificateMapper _mapper;
    private readonly Validation<EmployeeCertificate> _validation;
    private readonly ILogger<EmployeeCertificate> _logger;

    public EmployeeCertificateService(ApplicationDbContext context, IEmployeeCertificateMapper mapper, Validation<EmployeeCertificate> validation, ILogger<EmployeeCertificate> logger)
    {
        _context = context;
        _mapper = mapper;
        _validation = validation;
        _logger = logger;
    }
    public async Task<EmployeeCertificateResponse> CreateEmployeeCertificateAsync(EmployeeCertificateCreate create)
    {
        
        var employee = await _context.Employees
        .Include(e => e.EmployeeCertificates)
        .FirstOrDefaultAsync(e => e.Id == create.EmployeeId);
        var existCertiId = employee.EmployeeCertificates.Any(c => c.CertificateId == create.CertificateId && c.Status == CertificateD.Active);
        if(existCertiId)
        {
            throw new Exception("Nhân viên đã có chứng chỉ và chưa hết hạn");
        }
        if (employee == null)
            throw new Exception("nhân viên không tồn tại");
        var activeCount = employee.EmployeeCertificates
        .Count(ec => ec.Status == CertificateD.Active); 

        if(create.IssueDate > create.ExpiredDate)
        {
            throw new Exception("Ngày cấp phép không thể lớn hơn ngày hết hạn");
        }
        if (activeCount >= 3)
        {
            _logger.LogWarning($"Nhân Viên {employee.Id}: {employee.Name} đã có đủ 3 chứng chỉ đang hoạt động.");
            throw new Exception("Nhân viên đã có tối đa 3 chứng chỉ đang hoạt động không thể thêm");
        }
        var newCertificate = new EmployeeCertificate
        {
            EmployeeId = create.EmployeeId,
            CertificateId = create.CertificateId,
            IssueDate = create.IssueDate,
            ExpiredDate = create.ExpiredDate,
            Status = CertificateD.Active 
        };
        _context.EmployeeCertificates.Add(newCertificate);

        // Cập nhật số đếm
        employee.TotalCertificateCount++;
        employee.ActiveCertificateCount = activeCount + 1;

        await _context.SaveChangesAsync();
        var response = _mapper.EntityToResponse(newCertificate);
        return response;
    }

    public async Task<EmployeeCertificateResponse> FindEmployeeCertificateByIdAsync(int id)
    {
        var tId = await _context.EmployeeCertificates.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có bản nào chứa Id {id}");
        var response = _mapper.EntityToResponse(tId);
        return response;
    }

    public async Task<IEnumerable<EmployeeCertificateResponse>> GetAllEmployeeCertificatesAsync()
    {
        var tId = await _context.EmployeeCertificates.ToListAsync();
        if (tId == null) throw new Exception($"Không có bản nào");
        var response = _mapper.ListEntityToResponse(tId);
        return response;
    }

    public async Task<bool> HardDeleteEmployeeCertificateAsync(int id)
    {
        var tId = await _context.EmployeeCertificates.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không có bản nào chứa Id {id}");

        _context.EmployeeCertificates.Remove(tId);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ScanAndUpdateCertificateAsync()
    {
        //Hàm check Certificate còn hoạt động hay không
        _logger.LogInformation($"Chạy hàm {nameof(ScanAndUpdateCertificateAsync)}");

        var today = DateTime.Now;

        var expiredCertificates = await _context.EmployeeCertificates
            .Include(ec => ec.Certificate)
            .Include(ec => ec.Employee)
            .Where(ec => ec.ExpiredDate <= today && ec.Status != CertificateD.Expired)
            .ToListAsync();

        if (expiredCertificates.Any())
        {
            foreach (var ec in expiredCertificates)
            {
                ec.Status = CertificateD.Expired;

                var employee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.Id == ec.EmployeeId);

                if (employee != null && employee.ActiveCertificateCount > 0)
                {
                    employee.ActiveCertificateCount--;
                }

            }

            await _context.SaveChangesAsync();
            _logger.LogInformation($"{expiredCertificates.Count} chứng chỉ đã được cập nhật trạng thái Hết hạn(Expired).");
        }
        else
        {
            _logger.LogInformation("Không có chứng chỉ nào cần cập nhật trạng thái.");
        }

        _logger.LogInformation($"Thời gian hiện tại: {today}");
        foreach (var ec in expiredCertificates)
        {
            _logger.LogInformation($"Nhân viên: {ec.Employee.Name} - Chứng chỉ: {ec.Certificate.Name} - Ngày hết hạn: {ec.ExpiredDate} - Trạng thái: {ec.Status}");
        }

        return true;
    }

    public async Task<EmployeeCertificateResponse> UpdateEmployeeCertificateAsync(int id, EmployeeCertificateUpdate update)
    {
        var tId = await _context.EmployeeCertificates.FirstOrDefaultAsync(t => t.Id == id);
        if (tId == null) throw new Exception($"Không tồn tại Id {id}");

        tId.IssueDate = await _validation.CheckAndUpdateDateAsync(tId, tId.IssueDate, update.IssueDate, tId.ExpiredDate, true);
        tId.ExpiredDate = await _validation.CheckAndUpdateDateAsync(tId, tId.ExpiredDate, update.ExpiredDate, tId.IssueDate, false);
        tId.CertificateId = await _validation.CheckAndUpdateQuantityAsync(tId, tId.CertificateId, update.CertificateId, co => co.CertificateId == update.CertificateId);
        tId.EmployeeId = await _validation.CheckAndUpdateQuantityAsync(tId, tId.EmployeeId, update.EmployeeId, co => co.EmployeeId == update.EmployeeId);
        
        var result = _mapper.UpdateToEntity(update);
        tId.Status = result.Status;
        await _context.SaveChangesAsync();
        var response = _mapper.EntityToResponse(tId);
        return response;

    
    }

    public async Task<IEnumerable<EmployeeCertificateResponse>> GetActiveCertificatesByEmployeeIdAsync(int Id)
    {
        var activeCertificates = await _context.EmployeeCertificates
        .Where(ec => ec.EmployeeId == Id && ec.Status == CertificateD.Active)
        .ToListAsync();

        if (!activeCertificates.Any())
        {
            throw new Exception("Nhân viên không có văn bằng nào đang hoạt động");
        }
        var response = _mapper.ListEntityToResponse(activeCertificates);
        return response;
    }
}
