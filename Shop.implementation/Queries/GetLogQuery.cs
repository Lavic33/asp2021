using Shop.Application.DTO;
using Shop.Application.Exceptions;
using Shop.Application.Queries;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Implementation.Queries
{
    public class GetLogQuery : IGetLogQuery
    {
        private readonly ShopContext _context;

        public GetLogQuery(ShopContext context)
        {
            _context = context;
        }

        public int Id => 20;

        public string Name => "Get log";

        public GetLogDTO Execute(int search)
        {
            var query = _context.Logs.Find(search);

            if (query == null)
                throw new NotFoundException(search, typeof(Log));

            return new GetLogDTO
            {
                Id = query.Id,
                CreatedAt = query.CreatedAt,
                Data = query.Data,
                UseCase = query.UseCaseName,
                User = _context.Users.Where(x => x.Email == query.Actor).Select(y => new UserDTO
                {
                    Id = y.Id,
                    Email = y.Email,
                    FirstName = y.FirstName,
                    Adress = y.Adress,
                     City = y.City,
                    LastName = y.LastName

                }).First()

            };
        }
    }

}
