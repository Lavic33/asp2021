using Shop.DataAccess;
using System;
using Shop.Application.Commands;
using System.Collections.Generic;
using System.Text;
using Shop.Application.DTO;
using Shop.Domain;
using Shop.Application.Commands.User;

namespace Shop.Implementation.Commands.UserCommands
{
    class CreateUserCommand : IRegisterUserCommand
    {
        private readonly ShopContext _ctx;
        public CreateUserCommand(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public int Id => 41;

        public string Name => "User create";

        public void Execute(UserDTO request)
        {

            var user = new User
            {

                FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            City = request.City,
            Adress = request.Adress,
        };

            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }
    }
}
