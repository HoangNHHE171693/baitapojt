using Hoangnhhe171693.Models.DTO.Request.Employee;
using Hoangnhhe171693.Models.DTO.Response;
using Hoangnhhe171693.Models;
using Hoangnhhe171693.Models.DTO.Request.Certificate;

namespace Hoangnhhe171693.Mapper;

public interface ICertificateMapper
{
    Certificate CreateToEntity(CertificateCreate create);
    Certificate UpdateToEntity(CertificateUpdate update);
    Certificate DeleteToEntity(CertificateDelete delete);

    CertificateResponse EntityToResponse(Certificate entity);
    IEnumerable<CertificateResponse> ListEntityToResponse(IEnumerable<Certificate> entities);
}
