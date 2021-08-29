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
    public class CategoryController : ControllerBase
    {
        private readonly IAppActor actor;
        private readonly UseCaseExec executor;

        public CategoryController(IAppActor actor, UseCaseExec executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearch search,
            [FromServices] IGetCategories query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] int search, [FromServices] IGetCategory query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDTO dto, [FromServices] ICreateCategoryCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);


        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDTO dto, [FromServices] IUpdateCategoryCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();


        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
