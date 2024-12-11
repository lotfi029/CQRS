using CQRS_V00.Commands;
using CQRS_V00.Contract;
using CQRS_V00.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;

namespace CQRS_V00.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeesController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] EmployeeRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new AddCommand(request), cancellationToken);

        return response.IsSuccess ? CreatedAtAction(nameof(Get), new { id = response.Value}, null) : BadRequest(response.Error);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Updatae([FromRoute] Guid id, [FromBody] EmployeeRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new UpdateCommand(id, request), cancellationToken);

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }
    [HttpPut("{id}/toggle-status")]
    public async Task<IActionResult> ToggleStatus([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new ToggleStatusCommand(id), cancellationToken);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }   
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetQuery(id), cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllQuery(), cancellationToken);

        return Ok(response);
    } 
}
