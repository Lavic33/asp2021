using Shop.Application.Commands.Order;
using Shop.Application.DTO;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Commands.OrderCommands
{
   
    public class NewOrderComand : ICreateOrderCommand
    {
        private readonly ShopContext _ctx;
        public NewOrderComand(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public int Id => 22;

        public string Name => "New Order";

        public void Execute(OrderDTO request)
        {
            var order = new Order
            {
                 UserId = request.UserId,
                  Note = request.Note,
                  OrderStatusId = request.OrderStatusId,
                   IsActive = true
            };

            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
        }
    }

}
