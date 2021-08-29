using FluentValidation;
using Shop.Application.DTO;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Implementation.Validations
{
    public class OrderVal : AbstractValidator<UserDTO>
    {
        public OrderVal(ShopContext context)
        {
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Adress is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
        

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.");



        }
    }
}
