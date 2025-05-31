using HRM.Application.Common.Interfaces.Services;
using HRM.Application.Features.Employees.Commands;
using HRM.Application.Features.Employees.Queries;
using HRM.WebFramework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebAPI.Controllers.v1;

[ApiVersion("1.0")]
public class EmployeesController : BaseController<EmployeesController>
{
    private readonly IEmployeeService _service;

    public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService service) : base(logger)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var id = await Mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}/delete")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new DeleteEmployeeCommand(id), cancellationToken);
        return result ? NoContent() : NotFound();
    }

    [HttpPost("{id:guid}/restore")]
    public async Task<IActionResult> Restore(Guid id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new RestoreEmployeeCommand(id), cancellationToken);
        return result ? NoContent() : NotFound();
    }

    [HttpGet("{id:guid}/get-by-id")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetEmployeeByIdQuery(id);
        var result = await Mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllEmployeesQuery query, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("get-deleted")]
    public async Task<IActionResult> GetDeleted([FromQuery] GetAllDeletedEmployeesQuery query, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}
