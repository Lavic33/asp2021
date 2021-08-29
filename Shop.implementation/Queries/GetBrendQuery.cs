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

    public class GetBrendQuery : IGetBrend
    {
        private readonly ShopContext _context;

        public GetBrendQuery(ShopContext context)
        {
            _context = context;
        }

        public int Id => 29;

        public string Name => "Get one brend.";

        public BrendDTO Execute(int search)
        {
            var query = _context.Brends.Find(search);

            if (query == null)
                throw new NotFoundException(search, typeof(Brend));
            return new BrendDTO
            {
                Id = query.Id,
                BrendName = query.BrendName
            };



        }
    }

}
