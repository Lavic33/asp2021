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
    public class GetBrendsQuery : IGetBrends
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;

        public GetBrendsQuery(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 18;

        public string Name => "Brend search.";

        public PagedResponse<BrendDTO> Execute(BrendSearch search)
        {
            var query = _context.Brends.AsQueryable();

            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);

            }

            if (!string.IsNullOrEmpty(search.BrendName) || !string.IsNullOrWhiteSpace(search.BrendName))
            {
                query = query.Where(x => x.BrendName.ToLower().Contains(search.BrendName.ToLower()));
            }
            return query.Paged<BrendDTO, Brend>(search, _mapper);
        }
    }


}
