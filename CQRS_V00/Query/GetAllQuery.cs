using CQRS_V00.Contract;
using MediatR;

namespace CQRS_V00.Query;

public record GetAllQuery : IRequest<IEnumerable<EmployeeResponse>>
{ }
