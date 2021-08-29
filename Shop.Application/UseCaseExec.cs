using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application
{
    public class UseCaseExec
    {
        private readonly IAppActor actor;
        private readonly IUseCaseLoger loger;

        public UseCaseExec(IAppActor actor, IUseCaseLoger loger)
        {
            this.actor = actor;
            this.loger = loger;
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            loger.Log(query, actor, search);
            if (!actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedAccessException();
            }
            return query.Execute(search);
        }
        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            loger.Log(command, actor, request);
            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedAccessException();
            }
            command.Execute(request);
        }

    }
}


