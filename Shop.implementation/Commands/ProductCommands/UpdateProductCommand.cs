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

namespace Shop.Implementation.Commands.ProductCommands
{
   
    public class UpdateUserCommand : IUpdateProductCommand
    {
        private readonly ShopContext _context;
        private readonly NewProdVal _validator;

        public UpdateUserCommand(ShopContext context, NewProdVal validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Update Product.";

        public void Execute(ProductDTO request)
        {
            _validator.ValidateAndThrow(request);

            var product = _context.Products.Find(request.Id);

            if (product == null)
            {
                throw new NotFoundException(request.Id, typeof(Product));

            }

            product.ProductName = request.ProductName;
            _context.SaveChanges();

        }
    }

}
