using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Mail
{
    public interface IMailSender
    {
        void Send(SendMailDto dto);
        public string FromEmail { get; }

    }
}
