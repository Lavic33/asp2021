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
using Microsoft.EntityFrameworkCore;
using Shop.Application;

namespace Shop.Implementation.Queries
{
    public class GetProducts : IGetProducts
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;

        public GetProducts(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Product search";

        public PagedResponse<ProductDTO> Execute(ProductSearch search)
        {
            var query = _context.Products.Include(x => x.Category)
                .Include(x => x.Brend).Include(x => x.Orders).AsQueryable();

            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);

            }

            if (!string.IsNullOrEmpty(search.ProductName) || !string.IsNullOrWhiteSpace(search.ProductName))
            {
                query = query.Where(x => x.ProductName.ToLower().Contains(search.ProductName.ToLower()) ||
                x.Description.ToLower().Contains(search.Description.ToLower()));
            }
            if (search.Price > 0)
            {
                query = query.Where(x => x.Price >= search.Price);

            }

            return query.Paged<ProductDTO, Product>(search, _mapper);

        }

     
    }

}
