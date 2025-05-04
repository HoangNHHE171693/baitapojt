using BaiTapOceanTech.Models.DTO.Request.Employee;
using BaiTapOceanTech.Models.DTO.Response;
using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Certificate;

namespace BaiTapOceanTech.Mapper;

public interface ICertificateMapper
{
    Certificate CreateToEntity(CertificateCreate create);
    Certificate UpdateToEntity(CertificateUpdate update);
    Certificate DeleteToEntity(CertificateDelete delete);

    CertificateResponse EntityToResponse(Certificate entity);
    IEnumerable<CertificateResponse> ListEntityToResponse(IEnumerable<Certificate> entities);
}
