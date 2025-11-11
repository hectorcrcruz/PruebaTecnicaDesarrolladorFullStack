using DTOs.Contracts;
using DTOs.Features.Tarea.Commands.Add;
using DTOs.Features.Tarea.Commands.Delete;
using DTOs.Features.Tarea.Commands.Up;
using DTOs.Features.Tarea.Queries.List;
using DTOs.Models.TareaVm;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TareaController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<TareaController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public TareaController(ILogger<TareaController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetTarea")]
        public async Task<ActionResult<IEnumerable<TareaModel>>> GetBills(int? Id)
        {
            var query = await _mediator.Send(new ListTareaQuery(Id));
            return Ok(query);
        }

        [HttpPost("CreateTarea")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTarea([FromBody] CreateTareaCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateTarea")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateTarea([FromBody] UpdateTareaCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("DeleteTarea")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> DeleteTarea([FromBody] DeleteTareaCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
