using FluentValidation;
using Shop.Application.DTO;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Implementation.Validations
{

        public class BrendVal : AbstractValidator<BrendDTO>
        {

            public BrendVal(ShopContext ctx)
            {
                RuleFor(x => x.BrendName).NotEmpty().WithMessage("Brend name can not be empty")
                    .DependentRules(() =>
                    {

                        RuleFor(x => x.BrendName).Must(y => !ctx.Brends.Any(x => x.BrendName == y))
                                            .WithMessage("Brend with same name already exsists ");

                    });

            }
        }
    }

