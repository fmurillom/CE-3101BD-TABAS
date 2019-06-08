using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using EASendMail;//add EASendMail namespace

namespace NancyRest
{
    public static class CorreoManager
    {
        public static void mandarCorreo(string to, string text)
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            // Your gmail email address
            oMail.From = "fmmurillom@gmail.com";

            // Set recipient email address
            oMail.To = to;

            // Set email subject
            oMail.Subject = "Tiquete de vuelo TECAirlines";

            // Set email body
            oMail.TextBody = text;
            // Gmail SMTP server address
            SmtpServer oServer = new SmtpServer("smtp.gmail.com");

            // Set 465 port
            oServer.Port = 465;

            // detect SSL/TLS automatically
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            // Gmail user authentication
            // For example: your email is "gmailid@gmail.com", then the user should be the same
            oServer.User = "fmurillom@gmail.com";
            oServer.Password = "franroks96";

            try
            {
                Console.WriteLine("start to send email over SSL ...");
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }


    }
}