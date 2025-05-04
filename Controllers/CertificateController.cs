using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Certificate;
using BaiTapOceanTech.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class CertificateController : ControllerBase
{
    private readonly ICertificateService _service;

    public CertificateController(ICertificateService service)
    {
        _service = service;
    }

    [HttpPost("add-certificate")]
    [ProducesResponseType(typeof(IEnumerable<Certificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddCertificateAsync([FromBody] CertificateCreate create)
    {
        try
        {
            var response = await _service.CreateCertificateAsync(create);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(IEnumerable<Certificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<IEnumerable<Certificate>>> GetAllCertificateAsync()
    {
        try
        {
            var response = await _service.GetAllCertificatesAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("find-by-name/{name}")]
    [ProducesResponseType(typeof(IEnumerable<Certificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindByNameAsync(string name)
    {
        try
        {
            var response = await _service.SearchCertificateByKeyAsync(name);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("find-Id/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Certificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindByIdAsync(int id)
    {
        try
        {
            var response = await _service.FindCertificateByIdAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Certificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateCertificateAsync([FromBody] CertificateUpdate update, int id)
    {
        try
        {
            var response = await _service.UpdateCertificateAsync(id, update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("change-status/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Certificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SoftDeleteCertificateAsync(int id, CertificateD newStatus)
    {
        try
        {
            var response = await _service.SoftDeleteCertificateAsync(id, newStatus);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("delete-permanent/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Certificate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> HardDeleteCertificateAsync(int id)
    {
        try
        {
            var response = await _service.HardDeleteCertificateAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
