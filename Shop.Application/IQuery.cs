using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application
{
    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }
}
