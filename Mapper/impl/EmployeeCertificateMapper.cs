using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.EmployeeCertificate;
using BaiTapOceanTech.Models.DTO.Response;

namespace BaiTapOceanTech.Mapper.impl;

public class EmployeeCertificateMapper : IEmployeeCertificateMapper
{
    
    public EmployeeCertificate CreateToEntity(EmployeeCertificateCreate create)
    {
        EmployeeCertificate ec = new EmployeeCertificate();
        ec.IssueDate = TimeZoneInfo.ConvertTimeToUtc(create.IssueDate).AddHours(7);
        ec.ExpiredDate = TimeZoneInfo.ConvertTimeToUtc(create.ExpiredDate).AddHours(7);
        ec.EmployeeId = create.EmployeeId;
        ec.CertificateId = create.CertificateId;
        ec.Status = create.Status;
        return ec;
    }

    public EmployeeCertificate DeleteToEntity(EmployeeCertificateDelete delete)
    {
        EmployeeCertificate ec = new EmployeeCertificate();
        ec.Id = delete.Id;
        ec.IssueDate = delete.IssueDate;
        ec.ExpiredDate = delete.ExpiredDate;
        ec.EmployeeId = delete.EmployeeId;
        ec.CertificateId = delete.CertificateId;
        ec.Status = delete.Status;
        return ec;
    }

    public EmployeeCertificateResponse EntityToResponse(EmployeeCertificate entity)
    {
        EmployeeCertificateResponse response = new EmployeeCertificateResponse();
        response.Id = entity.Id;
        response.IssueDate = entity.IssueDate;
        response.ExpiredDate = entity.ExpiredDate;
        response.EmployeeId = entity.EmployeeId;
        response.CertificateId = entity.CertificateId;
        response.Status = entity.Status;
        return response;
    }

    public IEnumerable<EmployeeCertificateResponse> ListEntityToResponse(IEnumerable<EmployeeCertificate> entities)
    {
        return entities.Select(x => EntityToResponse(x)).ToList();
    }

    public EmployeeCertificate UpdateToEntity(EmployeeCertificateUpdate update)
    {
        EmployeeCertificate ec = new EmployeeCertificate();
        ec.IssueDate = update.IssueDate;
        ec.ExpiredDate = update.ExpiredDate;
        ec.EmployeeId = update.EmployeeId;
        ec.CertificateId = update.CertificateId;
        ec.Status = update.Status;
        return ec;
    }
}
