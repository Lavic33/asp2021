using Shop.Application.Commands.Brend;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Commands.BrendCommands
{
    public class DeleteCat : IDeleteCategoryCommand
    {
        private readonly ShopContext _ctx;
        public DeleteCat(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public int Id => 2;

        public string Name =>"deleting cat";

        public void Execute(int request)
        {
            var cat = _ctx.Categories.Find(request);

            if (cat != null)
            {
                cat.DeletedAt = DateTime.Now;
                cat.IsActive = false;
                cat.IsDeleted = true;
                _ctx.SaveChanges();

            }
            else throw new EntryPointNotFoundException();
        }
    }
}
