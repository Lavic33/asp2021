using Shop.DataAccess;
using Shop.Application.Commands.OrderStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Commands.OrderStatusCommands
{
  public  class DeleteOrderStatus : IDeleteOrderStatusCommand
    {
        private readonly ShopContext _ctx;
        public DeleteOrderStatus(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public int Id => 2;

        public string Name => "deleting order status";

        public void Execute(int request)
        {
            var orderStatus = _ctx.Statuses.Find(request);

            if (orderStatus != null)
            {
                orderStatus.DeletedAt = DateTime.Now;
                orderStatus.IsActive = false;
                orderStatus.IsDeleted = true;
                _ctx.SaveChanges();

            }
            else throw new EntryPointNotFoundException();
        }
    }
}
