using Microsoft.AspNetCore.Mvc;
using Shop.Application;
using Shop.Application.Commands.User;
using Shop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{

    public class RegUserController : ControllerBase
    {
        private readonly UseCaseExec _executor;

        public RegUserController(UseCaseExec executor)
        {
            _executor = executor;
        }

        // POST api/<RegisterController>
        [HttpPost]
        public void Post([FromBody] UserDTO dto, [FromServices] IRegisterUserCommand command)
        {

            _executor.ExecuteCommand(command, dto);
        }


    }

}
