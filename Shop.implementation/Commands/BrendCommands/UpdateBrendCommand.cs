using FluentValidation;
using Shop.Application.Commands.Brend;
using Shop.Application.DTO;
using Shop.Application.Exceptions;
using Shop.DataAccess;
using Shop.Domain;
using Shop.Implementation.Validations;
using System;
using System.Collections.Generic;
using System.Text;


namespace Shop.Implementation.Commands.BrendCommands
{ 
    public class UpdateBrendCommand : IUpdateBrendCosmmand
    {
        private readonly ShopContext _context;
        private readonly BrendVal _validator;

        public UpdateBrendCommand(ShopContext context, BrendVal validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 24;

        public string Name => "Update Brend.";

        public void Execute(BrendDTO request)
        {
            _validator.ValidateAndThrow(request);

            var brend = _context.Brends.Find(request.Id);

            if (brend == null)
            {
                throw new NotFoundException(request.Id, typeof(Brend));

            }

            brend.BrendName = request.BrendName;
            _context.SaveChanges();

        }
    }

}
