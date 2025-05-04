using Hoangnhhe171693.Models;
using Hoangnhhe171693.Models.DTO.Request.Tinh;
using Hoangnhhe171693.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class TinhController : ControllerBase
{
    private readonly ITinhService _service;

    public TinhController(ITinhService service)
    {
        _service = service;
    }

    [HttpPost("add-tinh")]
    [ProducesResponseType(typeof(IEnumerable<Tinh>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddTinhAsync([FromBody] TinhCreate create)
    {
        try
        {
            var response = await _service.CreateTinhAsync(create);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(IEnumerable<Tinh>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<IEnumerable<Tinh>>> GetAllTinhAsync()
    {
        try
        {
            var response = await _service.GetAllTinhsAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("find-by-name/{name}")]
    [ProducesResponseType(typeof(IEnumerable<Tinh>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindByNameAsync(string name)
    {
        try
        {
            var response = await _service.SearchTinhByKeyAsync(name);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpGet("find-Id/{postalCode}")]
    [ProducesResponseType(typeof(IEnumerable<Tinh>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FindByIdAsync(int postalCode)
    {
        try
        {
            var response = await _service.FindTinhByIdAsync(postalCode);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Tinh>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateTinhAsync([FromBody] TinhUpdate update, int id)
    {
        try
        {
            var response = await _service.UpdateTinhAsync(id, update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpPut("change-status/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Tinh>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SoftDeleteTinhAsync(int id, Statuss newStatus)
    {
        try
        {
            var response = await _service.SoftDeleteTinhAsync(id, newStatus);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }

    [HttpDelete("delete-permanent/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Tinh>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> HardDeleteTinhAsync(int id)
    {
        try
        {
            var response = await _service.HardDeleteTinhAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message });
        }
    }
}
