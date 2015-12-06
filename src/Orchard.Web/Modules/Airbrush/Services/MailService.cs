
using Airbrush.Models;
using System;
using System.Net.Mail;
using System.Text;

namespace Airbrush.Services
{
    public class MailService
    {
        public static void SendMail(ContactFormEntry contactFormEntry)
        {
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.UseDefaultCredentials = false;
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential(MailCredentials.SENDER, MailCredentials.PW);
                    client.Host = "smtp.gmail.com";
                    client.Timeout = 30000;

                    MailMessage mail = new MailMessage(MailCredentials.SENDER, MailCredentials.RECEIVER);
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
