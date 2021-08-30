using Newtonsoft.Json;
using Shop.Application;
using Shop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Logger
{

    public class LogUseCase : IUseCaseLoger
    {
        private readonly ShopContext _context;

        public LogUseCase(ShopContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IAppActor actor, object data)
        {
            _context.Logs.Add(new Domain.Log
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(data),
                UseCaseName = useCase.Name
            });

            _context.SaveChanges();
        }
    }

}
