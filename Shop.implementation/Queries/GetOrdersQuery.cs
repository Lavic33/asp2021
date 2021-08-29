using AutoMapper;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Application.Queries;
using Shop.Application.DTO;
using Shop.Application.SearchParams;
using System.Linq;
using Shop.Domain;

namespace Shop.Implementation.Queries
{
    public class GetOrdersQuery : IGetOrdersQuery
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;

        public GetOrdersQuery(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 33;

        public string Name => "Order search.";

        public PagedResponse<OrderDTO> Execute(OrderSearch search)
        {
            var query = _context.Orders.AsQueryable();

            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);

            }

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Note.ToLower().Contains(search.Keyword.ToLower()));
            }
            return query.Paged<OrderDTO, Order>(search, _mapper);
        }
    }


}
