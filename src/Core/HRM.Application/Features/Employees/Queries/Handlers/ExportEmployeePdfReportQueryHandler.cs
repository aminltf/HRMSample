using HRM.Application.Common.Interfaces.Repositories;
using HRM.Application.Common.Interfaces.Services;
using MediatR;

namespace HRM.Application.Features.Employees.Queries.Handlers;

internal class ExportEmployeePdfReportQueryHandler : IRequestHandler<ExportEmployeePdfReportQuery, byte[]>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmployeeReportPdfService _reportService;

    public ExportEmployeePdfReportQueryHandler(IUnitOfWork unitOfWork, IEmployeeReportPdfService reportService)
    {
        _unitOfWork = unitOfWork;
        _reportService = reportService;
    }

    public async Task<byte[]> Handle(ExportEmployeePdfReportQuery request, CancellationToken cancellationToken)
    {
        var employees = await _unitOfWork.Employee.GetForReportAsync(request.Request, cancellationToken);

        return _reportService.Generate(employees, request.Request.SelectedFields);
    }
}
