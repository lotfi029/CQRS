using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_V00.Controllers;

public class BaseController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;
}