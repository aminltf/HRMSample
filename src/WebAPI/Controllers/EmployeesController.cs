#nullable disable

using Application.Common.Interfaces.Services.Reporting;
using Application.Common.Models;
using Application.Employees.Commands;
using Application.Employees.Dtos;
using Application.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IEmployeeReportPdfService _pdfService;

    public EmployeesController(IMediator mediator, IEmployeeReportPdfService pdfService)
    {
        _mediator = mediator;
        _pdfService = pdfService;
    }

    // POST: api/Employees/create
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    // GET: api/Employees/get-by-id
    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetEmployeeByIdQuery(id);
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    // GET: api/Employees/get
    [HttpGet("get")]
    public async Task<ActionResult<PagedResult<EmployeeReportDto>>> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var selectedFields = typeof(EmployeeReportDto).GetProperties().Select(p => p.Name).ToList();

        var result = await _mediator.Send(new GetEmployeesPagedQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SelectedFields = selectedFields
        });
        return Ok(result);
    }

    // POST: api/Employees/report
    [HttpPost("report")]
    public async Task<IActionResult> GenerateReport([FromBody] EmployeeReportRequest request)
    {
        var result = await _mediator.Send(new GetEmployeesPagedQuery
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            SelectedFields = request.SelectedFields
        });

        var pdfBytes = _pdfService.Generate(result.Items, request.SelectedFields);

        return File(pdfBytes, "application/pdf", "EmployeeReport.pdf");
    }
}
