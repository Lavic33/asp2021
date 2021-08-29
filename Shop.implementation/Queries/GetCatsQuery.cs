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
    public class GetCatsQuery : IGetCategories
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;

        public GetCatsQuery(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Category search.";

        public PagedResponse<CategoryDTO> Execute(CategorySearch search)
        {
            var query = _context.Categories.AsQueryable();

            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);

            }

            if (!string.IsNullOrEmpty(search.CategoryName) || !string.IsNullOrWhiteSpace(search.CategoryName))
            {
                query = query.Where(x => x.CategoryName.ToLower().Contains(search.CategoryName.ToLower()));
            }
            return query.Paged<CategoryDTO, Brend>(search, _mapper);
        }
    }


}
