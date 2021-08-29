using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application;
using Shop.Application.Commands;
using Shop.Application.Commands.Order;
using Shop.Application.DTO;
using Shop.Application.Queries;
using Shop.Application.SearchParams;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IAppActor actor;
        private readonly UseCaseExec executor;

        public OrderController(IAppActor actor, UseCaseExec executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search,
            [FromServices] IGetOrdersQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] int search, [FromServices] IGetOrder query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderDTO dto, [FromServices] ICreateOrderCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);


        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderDTO dto, [FromServices] IUpdateOrderCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }

}
