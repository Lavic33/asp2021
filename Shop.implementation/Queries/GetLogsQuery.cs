using AutoMapper;
using Shop.Application.DTO;
using Shop.Application.Queries;
using Shop.Application.SearchParams;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Implementation.Queries
{
    public class GetLogsQuery : IGetLogsQuery
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;

        public GetLogsQuery(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 16;

        public string Name => "Log search.";

        public PagedResponse<GetLogDTO> Execute(LogSearch search)
        {
            var query = _context.Logs.AsQueryable();
            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);

            }

            if (!string.IsNullOrEmpty(search.UseCase) || !string.IsNullOrWhiteSpace(search.UseCase))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCase));
            }


            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Username));
            }


            if ((search.StartDate.HasValue && search.EndDate.HasValue) && (search.StartDate < search.EndDate))
            {
                query = query.Where(x => x.CreatedAt >= search.StartDate && x.CreatedAt <= search.EndDate);
            }


            return query.Paged<GetLogDTO, Log>(search, _mapper);
        }
    }

}
