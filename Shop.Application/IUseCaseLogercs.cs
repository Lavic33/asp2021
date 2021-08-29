using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application
{
    public interface IUseCaseLoger
    {
        void Log(IUseCase useCase, IAppActor actor, object data);
    }
}
