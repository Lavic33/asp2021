using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Exceptions
{
    class UnauthorizedCaseException : Exception
    {
        public UnauthorizedCaseException(IUseCase useCase, IAppActor actor)
       : base($"Unauthorized user with id {actor.Id} - {actor.Identity} attepmted {useCase.Name}.")
        {

        }
    }
}
