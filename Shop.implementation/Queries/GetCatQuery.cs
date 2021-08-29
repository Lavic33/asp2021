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

    public class GetCatQuery : IGetCategory
    {
        private readonly ShopContext _context;

        public GetCatQuery(ShopContext context)
        {
            _context = context;
        }

        public int Id => 19;

        public string Name => "Get one category.";

        public CategoryDTO Execute(int search)
        {
            var query = _context.Categories.Find(search);

            if (query == null)
                throw new NotFoundException(search, typeof(Brend));
            return new CategoryDTO
            {
                Id = query.Id,
                CategoryName = query.CategoryName
            };



        }
    }

}
