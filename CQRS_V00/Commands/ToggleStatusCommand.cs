using CQRS_V00.Abstracts;
using MediatR;

namespace CQRS_V00.Commands;

public record ToggleStatusCommand(Guid Id) : IRequest<Result> { }