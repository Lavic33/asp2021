using FluentValidation;
using Shop.Application.Commands;
using Shop.Application.DTO;
using Shop.DataAccess;
using Shop.Domain;
using Shop.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Commands
{
    public class CreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly CategoryVal _val;
        private readonly ShopContext _ctx;
        public CreateCategoryCommand(ShopContext ctx,CategoryVal val)
        {
            _ctx = ctx;
            _val = val;
        }
        public int Id => 1;

        public string Name => "New Category";

        public void Execute(CategoryDTO request)
        {
            _val.ValidateAndThrow(request);
            var cat = new Brend
            {
                CategoryName = request.CategoryName
            };

            _ctx.Categories.Add(cat);
            _ctx.SaveChanges();
        }
    }
}
