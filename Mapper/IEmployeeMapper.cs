using BaiTapOceanTech.Models.DTO.Request.Xa;
using BaiTapOceanTech.Models.DTO.Response;
using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Employee;

namespace BaiTapOceanTech.Mapper;

public interface IEmployeeMapper
{
    Employee CreateToEntity(EmployeeCreate create);
    Employee UpdateToEntity(EmployeeUpdate update);
    Employee DeleteToEntity(EmployeeDelete delete);

    EmployeeResponse EntityToResponse(Employee entity);
    IEnumerable<EmployeeResponse> ListEntityToResponse(IEnumerable<Employee> entities);
}
