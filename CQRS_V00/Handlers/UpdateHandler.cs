using CQRS_V00.Abstracts;
using CQRS_V00.Commands;
using CQRS_V00.Services;
using MediatR;

namespace CQRS_V00.Handlers;

public class UpdateHandler(IEmployeeService employeeService) : IRequestHandler<UpdateCommand, Result>
{
    private readonly IEmployeeService _employeeService = employeeService;

    public async Task<Result> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var respone = await _employeeService.UpdateAsync(request.Id, request.Request, cancellationToken);

        return respone;
    }
}
