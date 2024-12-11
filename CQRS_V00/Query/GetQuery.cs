using CQRS_V00.Abstracts;
using CQRS_V00.Contract;
using MediatR;

namespace CQRS_V00.Query;

public record GetQuery(Guid Id) : IRequest<Result<EmployeeResponse>> { }
