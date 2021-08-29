using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application;
using Shop.Application.Commands;
using Shop.Application.Commands.Brend;
using Shop.Application.DTO;
using Shop.Application.Queries;
using Shop.Application.SearchParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrendController : ControllerBase
    {
        private readonly IAppActor actor;
        private readonly UseCaseExec executor;

        public BrendController(IAppActor actor, UseCaseExec executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] BrendSearch search,
            [FromServices] IGetBrends query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] int search, [FromServices] IGetBrend query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BrendDTO dto, [FromServices] ICreateBrendCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);


        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BrendDTO dto, [FromServices] IUpdateBrendCosmmand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrendCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
