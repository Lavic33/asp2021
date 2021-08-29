using Shop.Application.Commands.Product;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Commands.UserCommands
{
    class DeleteUserCommand : IDeleteProductCommand
    {
        private readonly ShopContext _ctx;
        public DeleteUserCommand(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public int Id => 2;

        public string Name => "deleting Product";

        public void Execute(int request)
        {
            var product = _ctx.Products.Find(request);

            if (product != null)
            {
                product.DeletedAt = DateTime.Now;
                product.IsActive = false;
                product.IsDeleted = true;
                _ctx.SaveChanges();

            }
            else throw new EntryPointNotFoundException();
        }
    }
}
