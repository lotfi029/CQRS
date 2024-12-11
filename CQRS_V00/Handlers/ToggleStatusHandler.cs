using CQRS_V00.Abstracts;
using CQRS_V00.Commands;
using CQRS_V00.Services;
using MediatR;

namespace CQRS_V00.Handlers;

public class ToggleStatusHandler(IEmployeeService employeeService) : IRequestHandler<ToggleStatusCommand, Result>
{
    private readonly IEmployeeService _employeeService = employeeService;

    public async Task<Result> Handle(ToggleStatusCommand request, CancellationToken cancellationToken)
    {
        var respone = await _employeeService.ToggleStatusAsync(request.Id, cancellationToken);

        return respone;
    }
}
