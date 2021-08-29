using Abp.Net.Mail;
using Shop.Application.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Implementation.SMTPMail
{
  
    public class SMPTMail : IMailSender
    {

        private readonly string _fromEmail;
        private readonly string _fromPassword;

        public SMPTMail(string fromEmail, string fromPassword)
        {
            _fromEmail = fromEmail;
            _fromPassword = fromPassword;
        }

        public string FromEmail => _fromEmail;

        public void Send(SendMailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromEmail, _fromPassword)
            };

            var message = new MailMessage(_fromPassword, dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
