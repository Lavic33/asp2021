using FluentValidation;
using Shop.Application.DTO;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Implementation.Validations
{

        public class CategoryVal : AbstractValidator<CategoryDTO>
        {

            public CategoryVal(ShopContext ctx)
            {
                RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name can not be empty")
                    .DependentRules(() =>
                    {

                        RuleFor(x => x.CategoryName).Must(y => !ctx.Categories.Any(x => x.CategoryName == y))
                                            .WithMessage("Category with same name already exsists ");

                    });

            }
        }
    }

