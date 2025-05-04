using Hoangnhhe171693.Models.DTO.Request.Xa;
using Hoangnhhe171693.Models.DTO.Response;
using Hoangnhhe171693.Models;
using Hoangnhhe171693.Models.DTO.Request.Employee;

namespace Hoangnhhe171693.Mapper;

public interface IEmployeeMapper
{
    Employee CreateToEntity(EmployeeCreate create);
    Employee UpdateToEntity(EmployeeUpdate update);
    Employee DeleteToEntity(EmployeeDelete delete);

    EmployeeResponse EntityToResponse(Employee entity);
    IEnumerable<EmployeeResponse> ListEntityToResponse(IEnumerable<Employee> entities);
}
