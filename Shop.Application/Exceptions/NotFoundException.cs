using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id, Type type)
         : base($"Nothing found for {type.Name} with {id} id")
        {

        }
    }
}
