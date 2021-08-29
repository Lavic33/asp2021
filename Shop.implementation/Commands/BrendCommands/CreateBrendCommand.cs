using Shop.Application.Commands;
using Shop.Application.DTO;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Commands
{
    public class CreateBrendCommand : ICreateBrendCommand
    {
        private readonly ShopContext _ctx;
        public CreateBrendCommand(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public int Id => 1;

        public string Name => "New Brend";

        public void Execute(BrendDTO request)
        {
            var brend = new Brend
            {
                BrendName = request.BrendName
            };

            _ctx.Brends.Add(brend);
            _ctx.SaveChanges();
        }
    }
}
