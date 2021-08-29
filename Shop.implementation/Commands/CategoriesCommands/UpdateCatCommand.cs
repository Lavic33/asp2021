using FluentValidation;
using Shop.Application.Commands.Brend;
using Shop.Application.DTO;
using Shop.Application.Exceptions;
using Shop.DataAccess;
using Shop.Domain;
using Shop.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;


namespace Shop.Implementation.Commands.CategoriesCommands
{ 
    public class UpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly ShopContext _context;
        private readonly CategoryVal _validator;

        public UpdateCategoryCommand(ShopContext context, CategoryVal validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Update Category.";

        public void Execute(CategoryDTO request)
        {
            _validator.ValidateAndThrow(request);

            var category = _context.Categories.Find(request.Id);

            if (category == null)
            {
                throw new NotFoundException(request.Id, typeof(Brend));

            }

            category.CategoryName = request.CategoryName;
            _context.SaveChanges();

        }
    }

}
