using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain
{
    class Mail : Entity
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
    }
}
