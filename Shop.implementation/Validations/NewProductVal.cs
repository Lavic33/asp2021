using FluentValidation;
using Shop.Application.DTO;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Implementation.Validations
{
    public class NewProdVal : AbstractValidator<ProductDTO>
    {
        public NewProdVal(ShopContext context)
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product name is required!").DependentRules(() => {

                RuleFor(x => x.ProductName).Must(x => !context.Products.Any(y => y.ProductName == x)).WithMessage("Product name already exists");
            });
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description text is required!");

            RuleFor(x => x.Price).NotNull().GreaterThan(0).WithMessage("Price can not be 0 or lower");
            RuleFor(x => x.CategoryId).NotNull().GreaterThan(0).WithMessage("Product must have 1 category");
            RuleFor(x => x.BrendId).NotNull().GreaterThan(0).WithMessage("Product must have 1 brend");


        }

    }
}
