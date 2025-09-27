using HRM.Application.Features.Dependents.Commands;
using HRM.Application.Features.Dependents.Queries;
using HRM.WebFramework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebAPI.Controllers.v1;

[ApiVersion("1.0")]
public class DependentsController : BaseController<DependentsController>
{
    public DependentsController(ILogger<DependentsController> logger) : base(logger) { }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateDependentCommand command, CancellationToken cancellationToken)
    {
        var id = await Mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateDependentCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}/delete")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new DeleteDependentCommand(id), cancellationToken);
        return result ? NoContent() : NotFound();
    }

    [HttpPost("{id:guid}/restore")]
    public async Task<IActionResult> Restore(Guid id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new RestoreDependentCommand(id), cancellationToken);
        return result ? NoContent() : NotFound();
    }

    [HttpGet("{id:guid}/get-by-id")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetDependentByIdQuery(id);
        var result = await Mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllDependentsQuery query, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("get-deleted")]
    public async Task<IActionResult> GetDeleted([FromQuery] GetAllDeletedDependentsQuery query, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("by-employee/{employeeId}")]
    public async Task<IActionResult> GetByEmployeeId(Guid employeeId)
    {
        var result = await Mediator.Send(new GetDependentsByEmployeeIdQuery(employeeId));
        return Ok(result);
    }
}
