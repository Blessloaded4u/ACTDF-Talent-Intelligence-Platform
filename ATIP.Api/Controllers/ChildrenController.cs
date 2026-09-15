using ATIP.Core.DTOs.Children;
using ATIP.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ATIP.Core.Enums;

namespace ATIP.Api.Controllers;

[ApiController]
[Route("api/children")]
public class ChildrenController : ControllerBase
{
    private readonly IChildService _childService;

    public ChildrenController(IChildService childService)
    {
        _childService = childService;
    }

    [HttpPost]
    public async Task<ActionResult> Create(
        [FromBody] CreateChildRequest request)
    {
        var child = await _childService.CreateAsync(request);

        return Ok(child);
    }

    [HttpGet("{childId:int}")]
    public async Task<ActionResult> GetById(int childId)
    {
        var child = await _childService.GetByIdAsync(childId);

        if (child is null)
        {
            return NotFound();
        }

        return Ok(child);
    }

    [HttpGet]
    public async Task<ActionResult> GetAll(
    [FromQuery] ChildStatus? status = null)
    {
        var children = await _childService.GetAllAsync(status);

        return Ok(children);
    }

    [HttpPatch("{childId:int}")]
    public async Task<ActionResult> Update(
    int childId,
    [FromBody] UpdateChildRequest request)
    {
        var child = await _childService.UpdateAsync(
            childId,
            request);

        if (child is null)
        {
            return NotFound();
        }

        return Ok(child);
    }

    [HttpDelete("{childId:int}")]
    public async Task<ActionResult> Archive(int childId)
    {
        var archived = await _childService.ArchiveAsync(childId);

        if (!archived)
        {
            return NotFound();
        }

        return NoContent();
    }
}