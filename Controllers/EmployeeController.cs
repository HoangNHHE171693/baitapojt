using Hoangnhhe171693.Models.DTO.Request.Employee;
using Hoangnhhe171693.Models;
using Hoangnhhe171693.Services;
using Microsoft.AspNetCore.Mvc;
using static Hoangnhhe171693.Utility.Status;
using System.Net;

namespace Hoangnhhe171693.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpPost("add-employee")]
    [ProducesResponseType(typeof(IEnumerable<Employee>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeCreate create)
    {
        try
        {
            var response = await _service.CreateEmployeeAsync(create);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(IEnumerable<Employee>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeeAsync()
    {
        try
        {
            var response = await _service.GetAllEmployeesAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("find-by-name/{name}")]
    [ProducesResponseType(typeof(IEnumerable<Employee>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindByNameAsync(string name)
    {
        try
        {
            var response = await _service.SearchEmployeeByKeyAsync(name);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("find-Id/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Employee>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindByIdAsync(int id)
    {
        try
        {
            var response = await _service.FindEmployeeByIdAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Employee>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateEmployeeAsync([FromBody] EmployeeUpdate update, int id)
    {
        try
        {
            var response = await _service.UpdateEmployeeAsync(id, update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpPut("change-status/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Employee>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SoftDeleteEmployeeAsync(int id, EmployeeD newStatus)
    {
        try
        {
            var response = await _service.SoftDeleteEmployeeAsync(id, newStatus);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpDelete("delete-permanent/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Employee>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> HardDeleteEmployeeAsync(int id)
    {
        try
        {
            var response = await _service.HardDeleteEmployeeAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

}
