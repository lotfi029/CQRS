using CQRS_V00.Abstracts;
using CQRS_V00.Contract;

namespace CQRS_V00.Services;

public interface IEmployeeService
{
    Task<Result<Guid>> AddAsync(EmployeeRequest request, CancellationToken cancellationToken);
    Task<Result> UpdateAsync(Guid id, EmployeeRequest request, CancellationToken cancellationToken);
    Task<Result> ToggleStatusAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<EmployeeResponse>> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<EmployeeResponse>> GetAllAsync(CancellationToken cancellationToken);
}
