using Hoangnhhe171693.Models;
using Hoangnhhe171693.Models.DTO.Request.Huyen;
using Hoangnhhe171693.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class HuyenController : ControllerBase
{
    private readonly IHuyenService _service;

    public HuyenController(IHuyenService service)
    {
        _service = service;
    }

    [HttpPost("add-huyen")]
    [ProducesResponseType(typeof(IEnumerable<Huyen>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddHuyenAsync([FromBody] HuyenCreate create)
    {
        try
        {
            var response = await _service.CreateHuyenAsync(create);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = new {message = ex.Message } });
        }
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(IEnumerable<Huyen>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<IEnumerable<Huyen>>> GetAllHuyenAsync()
    {
        try
        {
            var response = await _service.GetAllHuyensAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("tinh/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Huyen>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> getHuyensByIdTinh(int id)
    {
        try
        {
            var response = await _service.getHuyenByIdTinhAsync(id);
            return Ok(response);

        }catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("find-by-name/{name}")]
    [ProducesResponseType(typeof(IEnumerable<Huyen>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindByNameAsync(string name)
    {
        try
        {
            var response = await _service.SearchHuyenByKeyAsync(name);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("find-Id/{postalCode}")]
    [ProducesResponseType(typeof(IEnumerable<Huyen>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindByIdAsync(int postalCode)
    {
        try
        {
            var response = await _service.FindHuyenByIdAsync(postalCode);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Huyen>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateHuyenAsync([FromBody] HuyenUpdate update, int id)
    {
        try
        {
            var response = await _service.UpdateHuyenAsync(id, update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpPut("change-status/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Huyen>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SoftDeleteHuyenAsync(int id, Statuss newStatus)
    {
        try
        {
            var response = await _service.SoftDeleteHuyenAsync(id, newStatus);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpDelete("delete-permanent/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Huyen>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> HardDeleteHuyenAsync(int id)
    {
        try
        {
            var response = await _service.HardDeleteHuyenAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }
}
