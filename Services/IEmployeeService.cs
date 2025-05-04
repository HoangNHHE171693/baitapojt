using Hoangnhhe171693.Models.DTO.Request.Employee;
using Hoangnhhe171693.Models.DTO.Response;
using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Services;

public interface IEmployeeService
{
    public Task<IEnumerable<EmployeeResponse>> GetAllEmployeesAsync();
    public Task<IEnumerable<EmployeeResponse>> SearchEmployeeByKeyAsync(string key);
    public Task<EmployeeResponse> UpdateEmployeeAsync(int id, EmployeeUpdate update);
    public Task<EmployeeResponse> CreateEmployeeAsync(EmployeeCreate create);
    public Task<bool> HardDeleteEmployeeAsync(int id);
    public Task<EmployeeResponse> SoftDeleteEmployeeAsync(int id, EmployeeD newStatus);
    public Task<EmployeeResponse> FindEmployeeByIdAsync(int id);
    public Task<string> CheckUniqueCodeAsync();
}
