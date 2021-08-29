using AutoMapper;
using Shop.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Implementation
{
    public static class QueryExtension
    {
        public static PagedResponse<TDto> Paged<TDto, TEntity>(
           this IQueryable<TEntity> query, Pagination search, IMapper mapper)
           where TDto : class
        {
            var skipCount = search.PerPage * (search.StartPage - 1);

            var skipped = query.Skip(skipCount).Take(search.PerPage);

            var response = new PagedResponse<TDto>
            {
                CurrentPage = search.StartPage,
                ItemsPerPage = search.PerPage,
                 TotalPages = query.Count(),
                Items = mapper.Map<IEnumerable<TDto>>(skipped)
            };

            return response;
        }
    }

}
