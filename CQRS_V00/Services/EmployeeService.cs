using CQRS_V00.Abstracts;
using CQRS_V00.Contract;
using CQRS_V00.Presistence;
using Mapster;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Threading;

namespace CQRS_V00.Services;

public class EmployeeService(ApplicationDbContext context) : IEmployeeService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<Guid>> AddAsync(EmployeeRequest request,CancellationToken cancellationToken)
    {
        var employee = request.Adapt<Employee>();

        await _context.AddAsync(employee);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(employee.Id);
    }
    public async Task<Result> UpdateAsync(Guid id, EmployeeRequest request, CancellationToken cancellationToken)
    {
        if (await _context.Employees.FindAsync(id, cancellationToken) is not { } employee)
            return Result.Failuer(new("Employee.NotFound", "Employee Not Found", StatusCodes.Status404NotFound));

        employee = request.Adapt(employee);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
    public async Task<Result> ToggleStatusAsync(Guid id, CancellationToken cancellationToken)
    {
        if (await _context.Employees.FindAsync(id, cancellationToken) is not { } employee)
            return Result.Failuer(new("Employee.NotFound", "Employee Not Found", StatusCodes.Status404NotFound));

        employee.Status = !employee.Status;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
    public async Task<Result<EmployeeResponse>> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        if (await _context.Employees.FindAsync(id, cancellationToken) is not { } employee)
            return Result.Failuer<EmployeeResponse>(new("Employee.NotFound", "Employee Not Found", StatusCodes.Status404NotFound));

        var response = employee.Adapt<EmployeeResponse>();

        return Result.Success(response);
    }
    public async Task<IEnumerable<EmployeeResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var respone = await _context.Employees.ProjectToType<EmployeeResponse>().ToListAsync(cancellationToken);

        return respone;
    }
}
