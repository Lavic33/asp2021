using Abp.Domain.Entities;
using Shop.Application.DTO;
using Shop.Application.Exceptions;
using Shop.Application.Queries;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Queries
{

    public class GetOrderQuery : IGetOrder
    {
        private readonly ShopContext _context;

        public GetOrderQuery(ShopContext context)
        {
            _context = context;
        }

        public int Id =>30;

        public string Name => "Get one oreder.";

        public OrderDTO Execute(int search)
        {
            var query = _context.Orders.Find(search);

            if (query == null)
                throw new NotFoundException(search, typeof(Order));
            return new OrderDTO
            {
                Id = query.Id,
                    OrderStatusId = query.OrderStatusId,
                     Note = query.Note,
                      UserId = query.UserId,
                       
            };



        }
    }

}
