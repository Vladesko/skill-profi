using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Statements.Application.Statements.Commands.CreateStatement;
using Statements.Application.Statements.Commands.DeleteCommand;
using Statements.Application.Statements.Commands.UpDateStatement;
using Statements.Application.Statements.Queries.GetStatementDetails;
using Statements.Application.Statements.Queries.GetStatementList;
using Statements.WebApi.Models;
using System.Diagnostics;

namespace Statements.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class StatementController : BaseController
    {
        private readonly IMapper _mapper;
        public StatementController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<StatementListViewModel>> GetAll()
        {
            var query = new GetStatementListQuery();

            var viewModel = await Mediator.Send(query);

            return Ok(viewModel);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StatementDetailsViewModel>> Get(Guid id)
        {
            var query = new GetStatementDetailsQuery() { Id = id };
            var viewModel = await Mediator.Send(query);

            return Ok(viewModel);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateStatementDto createStatementDto)
        {
            var command = _mapper.Map<CreateStatementCommand>(createStatementDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpDateStatementDto upDateStatementDto)
        {
            var command = _mapper.Map<UpDateStatementCommand>(upDateStatementDto);
            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteStatementCommand() { Id = id };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
