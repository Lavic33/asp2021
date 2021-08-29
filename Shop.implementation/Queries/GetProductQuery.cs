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

    public class GetProductQuery : IGetProduct
    {
        private readonly ShopContext _context;

        public GetProductQuery(ShopContext context)
        {
            _context = context;
        }

        public int Id => 22;

        public string Name => "Get one product";

        public ProductDTO Execute(int search)
        {

            var query = _context.Products.Find(search);

            if (query == null)
                throw new NotFoundException(search, typeof(SentEmails));

            return new ProductDTO
            {
                Id = query.Id,
                ProductName = query.ProductName,

                Description = query.Description,
                 BrendId = query.BrendId,
                 Price = query.Price,
                CreatedAt = query.CreatedAt,
                  CategoryId = query.CategoryId,
     
      

            };

        }
    }

}
