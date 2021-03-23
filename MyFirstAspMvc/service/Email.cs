using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace MyFirstAspMvc.service
{
    public class Email
    {
        public void Send(System.Net.Mail.MailMessage message) { }

        public static void CreateTestMessage(string server)
        {
            string to = "richmaniasson@gmail.com";
            string from = "harissonefares4@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Using the new SMTP client.";
            message.Body = @"Using this new feature, you can send an email message from an application very easly.";
            SmtpClient client = new SmtpClient(server);
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in  CreateTestMessage2():[0]",
                    ex.ToString());
            }
        }
    }
}