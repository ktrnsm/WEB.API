using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WEB.API.Tools
{
    public static class MailService
    {
        public static void Send(string reciever, string password="ktrnsmh123", string body="Testing Message", string subject="Email Test", string sender= "iktuerensemih@proton.me")
        {

            /*
              Use these settings:

Gmail SMTP server address: smtp.gmail.com
Gmail SMTP username: Your Gmail address (for example, example@gmail.com)
Gmail SMTP password: Your Gmail password
Gmail SMTP port (TLS): 587
Gmail SMTP port (SSL): 465
Gmail SMTP TLS/SSL required: Yes
             */
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(reciever);


            SmtpClient smpt = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject=subject,
                Body=body,
            })
            {
                smpt.Send(message);
            }
        }
    }
}