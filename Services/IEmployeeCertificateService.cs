using BaiTapOceanTech.Models.DTO.Request.EmployeeCertificate;
using BaiTapOceanTech.Models.DTO.Response;

namespace BaiTapOceanTech.Services;

public interface IEmployeeCertificateService
{
    public Task<IEnumerable<EmployeeCertificateResponse>> GetAllEmployeeCertificatesAsync();
    
    public Task<EmployeeCertificateResponse> UpdateEmployeeCertificateAsync(int id, EmployeeCertificateUpdate update);
    public Task<EmployeeCertificateResponse> CreateEmployeeCertificateAsync(EmployeeCertificateCreate create);
    public Task<bool> HardDeleteEmployeeCertificateAsync(int id);

    public Task<EmployeeCertificateResponse> FindEmployeeCertificateByIdAsync(int id);
    Task<bool> ScanAndUpdateCertificateAsync();

    Task<IEnumerable<EmployeeCertificateResponse>> GetActiveCertificatesByEmployeeIdAsync(int Id);
    //public Task<string> CheckUniqueCodeAsync();
}
