using CQRS_V00.Abstracts;
using CQRS_V00.Contract;
using MediatR;

namespace CQRS_V00.Commands;

public record UpdateCommand(Guid Id, EmployeeRequest Request) : IRequest<Result> { }