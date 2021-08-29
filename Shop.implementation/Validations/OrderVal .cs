using FluentValidation;
using Shop.Application.DTO;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Implementation.Validations
{
    public class RegisterVal : AbstractValidator<UserDTO>
    {
        public RegisterVal(ShopContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").DependentRules(() => {

                RuleFor(x => x.Email).Must(mail => !context.Users.Any(x => x.Email == mail))
                                .WithMessage("Mail already exists!");
            });
        

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");



        }
    }
}
