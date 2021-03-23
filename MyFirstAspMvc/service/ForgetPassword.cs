using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MyFirstAspMvc.service
{
    public class ForgetPassword
    {
        public ForgetPassword()
        {
        }

        public void SendMail()
        {
            string to, from, pass, messageBody;
            MailMessage message = new MailMessage();
            to = "root@localhost.com";
            from = "bfranck163@gmail.com";

            string HtmlHeader = "<a href=> http:\\localhost:52108"
        }
    }
}