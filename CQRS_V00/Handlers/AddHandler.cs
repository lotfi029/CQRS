using CQRS_V00.Abstracts;
using CQRS_V00.Commands;
using CQRS_V00.Services;
using MediatR;

namespace CQRS_V00.Handlers;

public class AddHandler(IEmployeeService employeeService) : IRequestHandler<AddCommand, Result<Guid>>
{
    private readonly IEmployeeService _employeeService = employeeService;

    public async Task<Result<Guid>> Handle(AddCommand request, CancellationToken cancellationToken)
    {
        var respone = await _employeeService.AddAsync(request.Request, cancellationToken);

        return respone;
    }
}
