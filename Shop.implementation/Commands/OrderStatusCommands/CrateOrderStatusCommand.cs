using Shop.Application.Commands;
using Shop.Application.DTO;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Commands.OrderStatusCommands
{
    public class CrateOrderStatusCommand : ICreateOrderStatus
    {
        private readonly ShopContext _ctx;
        public CrateOrderStatusCommand(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public int Id => 1;

        public string Name => "Order status create";

      

        public void Execute(OrderStatusDTO request)
        {
          
            
                var orderStatus = new OrderStatus
                {
                     OrderStatusName = request.OrderStatusName
                };

            _ctx.Statuses.Add(orderStatus);
                _ctx.SaveChanges();
            
        }
    }
}
