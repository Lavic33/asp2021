using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Mail
{
   public class SendMailDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SendTo { get; set; }
    }
}
