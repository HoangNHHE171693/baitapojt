using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Xa;
using BaiTapOceanTech.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class XaController : ControllerBase
{
    private readonly IXaService _service;

    public XaController(IXaService service)
    {
        _service = service;
    }

    [HttpPost("add-xa")]
    [ProducesResponseType(typeof(IEnumerable<Xa>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddXaAsync([FromBody] XaCreate create)
    {
        try
        {
            var response = await _service.CreateXaAsync(create);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(IEnumerable<Xa>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<IEnumerable<Xa>>> GetAllXaAsync()
    {
        try
        {
            var response = await _service.GetAllXasAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("huyen/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Xa>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> getXaByIdHuyen(int id)
    {
        try
        {
            var response = await _service.FindXaByIdHuyenAsync(id);
            return Ok(response);

        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("find-by-name/{name}")]
    [ProducesResponseType(typeof(IEnumerable<Xa>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindByNameAsync(string name)
    {
        try
        {
            var response = await _service.SearchXaByKeyAsync(name);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("find-Id/{postalCode}")]
    [ProducesResponseType(typeof(IEnumerable<Xa>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindByIdAsync(int postalCode)
    {
        try
        {
            var response = await _service.FindXaByIdAsync(postalCode);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Xa>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateXaAsync([FromBody] XaUpdate update, int id)
    {
        try
        {
            var response = await _service.UpdateXaAsync(id, update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpPut("change-status/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Xa>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SoftDeleteXaAsync(int id, Statuss newStatus)
    {
        try
        {
            var response = await _service.SoftDeleteXaAsync(id, newStatus);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpDelete("delete-permanent/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Xa>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> HardDeleteXaAsync(int id)
    {
        try
        {
            var response = await _service.HardDeleteXaAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }
}
