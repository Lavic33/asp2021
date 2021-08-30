using Shop.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Core
{
    public class UnauthrorizedActor : IAppActor
    {
        public int Id => 1;

        public string Identity => "Unauthorized";

        public IEnumerable<int> AllowedUseCases => new List<int>();
    }
}
