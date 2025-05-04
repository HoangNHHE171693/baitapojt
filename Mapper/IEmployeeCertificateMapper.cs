using Hoangnhhe171693.Models.DTO.Request.Certificate;
using Hoangnhhe171693.Models.DTO.Response;
using Hoangnhhe171693.Models;
using Hoangnhhe171693.Models.DTO.Request.EmployeeCertificate;

namespace Hoangnhhe171693.Mapper;

public interface IEmployeeCertificateMapper
{
    EmployeeCertificate CreateToEntity(EmployeeCertificateCreate create);
    EmployeeCertificate UpdateToEntity(EmployeeCertificateUpdate update);
    EmployeeCertificate DeleteToEntity(EmployeeCertificateDelete delete);

    EmployeeCertificateResponse EntityToResponse(EmployeeCertificate entity);
    IEnumerable<EmployeeCertificateResponse> ListEntityToResponse(IEnumerable<EmployeeCertificate> entities);
}
