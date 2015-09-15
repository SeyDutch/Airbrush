
using Airbrush.Models;
using System;
using System.Net.Mail;
using System.Text;

namespace Airbrush.Services
{
    public class MailService
    {
        private const string fromAddress = "ehfransen@gmail.com";
        private const string toAddress = "ehfransen@live.nl";

        public static void SendMail(ContactFormEntry contactFormEntry)
        {
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.Port = 25;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("ehfransen@gmail.com", "-----");
                    client.Host = "smtp.gmail.com";

                    MailMessage mail = new MailMessage(fromAddress, toAddress);
                    mail.Subject = contactFormEntry.Subject;
                    mail.Body = string.Format("Name: {0}\nEmail: {1}\nDatum: {2} om {3}\n\n{4}",
                        contactFormEntry.Name, contactFormEntry.Email, contactFormEntry.CreatedUtc.ToLongDateString(),
                        contactFormEntry.CreatedUtc.ToLongTimeString(), contactFormEntry.MessageBody);
                    mail.BodyEncoding = UTF8Encoding.UTF8;

                    client.Send(mail);
                    mail.Dispose();
                }
            }
            catch(Exception e)
            {
                int x = 0;
            }
        }
    }
}
