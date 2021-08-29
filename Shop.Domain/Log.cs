using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain
{
    public class Log : Entity
    {

        public string Data { get; set; }
        public string Actor { get; set; }
        public string UseCaseName { get; set; }



    }
}
