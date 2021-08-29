using Shop.Application.Commands.Brend;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Commands.BrendCommands
{
    public class DeleteBrend : IDeleteBrendCommand
    {
        private readonly ShopContext _ctx;
        public DeleteBrend(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public int Id => 2;

        public string Name =>"deleting brend";

        public void Execute(int request)
        {
            var brend = _ctx.Brends.Find(request);

            if (brend != null)
            {
                brend.DeletedAt = DateTime.Now;
                brend.IsActive = false;
                brend.IsDeleted = true;
                _ctx.SaveChanges();

            }
            else throw new EntryPointNotFoundException();
        }
    }
}
