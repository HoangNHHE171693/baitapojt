using Hoangnhhe171693.Models;
using Hoangnhhe171693.Models.DTO.Request.Certificate;
using Hoangnhhe171693.Models.DTO.Request.EmployeeCertificate;
using Hoangnhhe171693.Models.DTO.Response;
using Hoangnhhe171693.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hoangnhhe171693.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class EmployeeCertificateController : ControllerBase
{
    private readonly IEmployeeCertificateService _service;

    public EmployeeCertificateController(IEmployeeCertificateService service)
    {
        _service = service;
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(IEnumerable<EmployeeCertificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<IEnumerable<EmployeeCertificate>>> GetAllEmployeeCertificateAsync()
    {
        try
        {
            var response = await _service.GetAllEmployeeCertificatesAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpGet("get-certificate-by-employeeId")]
    [ProducesResponseType(typeof(IEnumerable<EmployeeCertificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<IEnumerable<EmployeeCertificateResponse>>> GetActiveCertificatesByEmployeeIdAsync([FromQuery] int id)
    {
        try
        {
            var response = await _service.GetActiveCertificatesByEmployeeIdAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("add-empcer")]
    [ProducesResponseType(typeof(IEnumerable<EmployeeCertificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddEmployeeCertificateAsync([FromBody] EmployeeCertificateCreate create)
    {
        try
        {
            var response = await _service.CreateEmployeeCertificateAsync(create);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("find-Id/{id}")]
    [ProducesResponseType(typeof(IEnumerable<EmployeeCertificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindByIdAsync(int id)
    {
        try
        {
            var response = await _service.FindEmployeeCertificateByIdAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(IEnumerable<EmployeeCertificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateEmployeeCertificateAsync([FromBody] EmployeeCertificateUpdate update, int id)
    {
        try
        {
            var response = await _service.UpdateEmployeeCertificateAsync(id, update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("delete-permanent/{id}")]
    [ProducesResponseType(typeof(IEnumerable<EmployeeCertificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> HardDeleteEmployeeCertificateAsync(int id)
    {
        try
        {
            var response = await _service.HardDeleteEmployeeCertificateAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
