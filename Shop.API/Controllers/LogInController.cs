using Microsoft.AspNetCore.Mvc;
using Shop.API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
    public class LoginController : ControllerBase
    {
        private readonly JWTManager manager;
        public LoginController(JWTManager manager)
        {
            this.manager = manager;
        }

        // POST api/<LoginController>
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest request)
        {
            var token = manager.MakeToken(request.Username, request.Password);

            if (token == null)
            {
                return Unauthorized();

            }
            return Ok(new { token });


        }





    }

}
