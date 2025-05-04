using Hoangnhhe171693.Models;
using Hoangnhhe171693.Models.DTO.Request.Employee;
using Hoangnhhe171693.Models.DTO.Response;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hoangnhhe171693.Mapper.impl;

public class EmployeeMapper : IEmployeeMapper
{
    
    public Employee CreateToEntity(EmployeeCreate create)
    {
        Employee emp = new Employee();
        emp.Name = create.Name;
        emp.Code = create.Code;
        emp.CCCD = create.CCCD;
        emp.Status = create.Status;
        emp.Job = create.Job;
        emp.Dob = create.Dob;
        emp.Ethnic = create.Ethnic;
        emp.Phone = create.Phone;
        emp.Age = create.Age;
        emp.CreatedDate = DateTime.Now.AddHours(7);
        emp.UpdatedDate = DateTime.Now.AddHours(7);
        emp.ActiveCertificateCount = create.ActiveCertificateCount;
        emp.TotalCertificateCount = create.TotalCertificateCount;
        emp.IdTinh = create.IdTinh;
        emp.IdHuyen = create.IdHuyen;
        emp.IdXa = create.IdXa;

        return emp;
    }

    public Employee DeleteToEntity(EmployeeDelete delete)
    {
        Employee emp = new Employee();
        emp.Id = delete.Id;
        emp.Name = delete.Name;
        emp.Code = delete.Code;
        emp.CCCD = delete.CCCD;
        emp.Job = delete.Job;
        emp.Dob = delete.Dob;
        emp.Ethnic = delete.Ethnic;
        emp.Phone = delete.Phone;
        emp.Age = delete.Age;
        emp.Status = delete.Status;
        emp.CreatedDate = DateTime.Now.AddHours(7);
        emp.UpdatedDate = DateTime.Now.AddHours(7);
        emp.ActiveCertificateCount = delete.ActiveCertificateCount;
        emp.TotalCertificateCount = delete.TotalCertificateCount;
        emp.IdTinh = delete.IdTinh;
        emp.IdHuyen = delete.IdHuyen;
        emp.IdXa = delete.IdXa;

        return emp;
    }

    public EmployeeResponse EntityToResponse(Employee entity)
    {
        EmployeeResponse response = new EmployeeResponse();
        response.Id = entity.Id;
        response.Name = entity.Name;
        response.Code = entity.Code;
        response.CCCD = entity.CCCD;
        response.Job = entity.Job;
        response.Dob = entity.Dob;
        response.Ethnic = entity.Ethnic;
        response.Phone = entity.Phone;
        response.Age = entity.Age;
        response.Status = entity.Status;
        response.CreatedDate = DateTime.Now.AddHours(7);
        response.UpdatedDate = DateTime.Now.AddHours(7);
        response.ActiveCertificateCount = entity.ActiveCertificateCount;
        response.TotalCertificateCount = entity.TotalCertificateCount;
        response.IdTinh = entity.IdTinh;
        response.IdHuyen = entity.IdHuyen;
        response.IdXa = entity.IdXa;

        return response;
    }

    public IEnumerable<EmployeeResponse> ListEntityToResponse(IEnumerable<Employee> entities)
    {
        return entities.Select(x => EntityToResponse(x)).ToList();
    }

    public Employee UpdateToEntity(EmployeeUpdate update)
    {
        Employee emp = new Employee();
        emp.Id = update.Id;
        emp.Name = update.Name;
        emp.Code = update.Code;
        emp.CCCD = update.CCCD;
        emp.Job = update.Job;
        emp.Dob = update.Dob;
        emp.Ethnic = update.Ethnic;
        emp.Phone = update.Phone;
        emp.Age = update.Age;
        emp.Status = update.Status;
        emp.CreatedDate = DateTime.Now.AddHours(7);
        emp.UpdatedDate = DateTime.Now.AddHours(7);
        emp.ActiveCertificateCount = update.ActiveCertificateCount;
        emp.TotalCertificateCount = update.TotalCertificateCount;
        emp.IdTinh = update.IdTinh;
        emp.IdHuyen = update.IdHuyen;
        emp.IdXa = update.IdXa;

        return emp;
    }
}
