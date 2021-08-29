using FluentValidation;
using Shop.Application.Commands.Order;
using Shop.Application.DTO;
using Shop.Application.Exceptions;
using Shop.DataAccess;
using Shop.Domain;
using Shop.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Commands.OrderCommands
{

    public class UpdateOrderCommand : IUpdateOrderCommand
    {
        private readonly ShopContext _context;
        private readonly OrderVal _validator;

        public UpdateOrderCommand(ShopContext context, OrderVal validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 28;

        public string Name => "Update Order.";

        public void Execute(OrderDTO request)
        {
           // _validator.ValidateAndThrow(request);

            var order = _context.Orders.Find(request.Id);

            if (order == null)
            {
                throw new NotFoundException(request.Id, typeof(Order));

            }
            order.UserId = request.UserId;
            order.Note = request.Note;
            order.OrderStatusId = request.OrderStatusId;
            _context.SaveChanges();

        }
    }

}
