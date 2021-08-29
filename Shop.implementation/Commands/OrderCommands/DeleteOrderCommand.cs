using Shop.Application.Commands.Order;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Commands.OrderCommands
{
 
    public class DeleteOrderCommand : IDeleteOrderCommand
    {
        private readonly ShopContext _ctx;
        public DeleteOrderCommand(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public int Id => 24;

        public string Name => "deleting order";

        public void Execute(int request)
        {
            var order = _ctx.Orders.Find(request);

            if (order != null)
            {
                order.DeletedAt = DateTime.Now;
                order.IsActive = false;
                order.IsDeleted = true;
                _ctx.SaveChanges();

            }
            else throw new EntryPointNotFoundException();
        }
    }

}
