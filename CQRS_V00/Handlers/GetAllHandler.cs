using CQRS_V00.Contract;
using CQRS_V00.Query;
using CQRS_V00.Services;
using MediatR;

namespace CQRS_V00.Handlers;

public class GetAllHandler(IEmployeeService employeeService) : IRequestHandler<GetAllQuery, IEnumerable<EmployeeResponse>>
{
    private readonly IEmployeeService _employeeService = employeeService;

    public async Task<IEnumerable<EmployeeResponse>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var respone = await _employeeService.GetAllAsync(cancellationToken);

        return respone;
    }
}
