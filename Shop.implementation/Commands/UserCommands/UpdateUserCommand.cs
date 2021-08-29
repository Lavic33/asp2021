using Shop.Application.Commands.Product;
using Shop.Application.DTO;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using Shop.Implementation.Validations;
using System.Text;
using FluentValidation;
using Shop.Application.Exceptions;
using Shop.Domain;
using Shop.Application.Commands.User;

namespace Shop.Implementation.Commands.UserCommands
{
   
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly ShopContext _context;
        private readonly RegisterVal _validator;

        public UpdateUserCommand(ShopContext context, RegisterVal validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Update User.";

        public void Execute(UserDTO request)
        {
            _validator.ValidateAndThrow(request);

            var user = _context.Users.Find(request.Id);

            if (user == null)
            {
                throw new NotFoundException(request.Id, typeof(Product));

            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.City = request.City;
            user.Adress = request.Adress;
            _context.SaveChanges();

        }
    }

}
