using CQRS_V00.Abstracts;
using CQRS_V00.Contract;
using CQRS_V00.Query;
using CQRS_V00.Services;
using MediatR;

namespace CQRS_V00.Handlers;

public class GetHandler(IEmployeeService employeeService) : IRequestHandler<GetQuery, Result<EmployeeResponse>>
{
    private readonly IEmployeeService _employeeService = employeeService;

    public async Task<Result<EmployeeResponse>> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        var respone = await _employeeService.GetAsync(request.Id, cancellationToken);

        return respone;
    }
}
