using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application
{
    
    public interface IAppActor
    {
        int Id { get; }
        string Identity { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
