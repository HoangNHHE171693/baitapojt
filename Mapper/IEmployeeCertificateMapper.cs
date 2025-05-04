using BaiTapOceanTech.Models.DTO.Request.Certificate;
using BaiTapOceanTech.Models.DTO.Response;
using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.EmployeeCertificate;

namespace BaiTapOceanTech.Mapper;

public interface IEmployeeCertificateMapper
{
    EmployeeCertificate CreateToEntity(EmployeeCertificateCreate create);
    EmployeeCertificate UpdateToEntity(EmployeeCertificateUpdate update);
    EmployeeCertificate DeleteToEntity(EmployeeCertificateDelete delete);

    EmployeeCertificateResponse EntityToResponse(EmployeeCertificate entity);
    IEnumerable<EmployeeCertificateResponse> ListEntityToResponse(IEnumerable<EmployeeCertificate> entities);
}
