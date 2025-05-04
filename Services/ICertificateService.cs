using Hoangnhhe171693.Models.DTO.Request.Certificate;
using Hoangnhhe171693.Models.DTO.Response;
using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Services;

public interface ICertificateService
{
    public Task<IEnumerable<CertificateResponse>> GetAllCertificatesAsync();
    public Task<IEnumerable<CertificateResponse>> SearchCertificateByKeyAsync(string key);
    public Task<CertificateResponse> UpdateCertificateAsync(int id, CertificateUpdate update);
    public Task<CertificateResponse> CreateCertificateAsync(CertificateCreate create);
    public Task<bool> HardDeleteCertificateAsync(int id);
    public Task<CertificateResponse> SoftDeleteCertificateAsync(int id, CertificateD newStatus);
    public Task<CertificateResponse> FindCertificateByIdAsync(int id);
    //public Task<string> CheckUniqueCodeAsync();
}
