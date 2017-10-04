using System;
using System.Net;
using System.Net.Mail;

namespace MSCCommon
{
    public class Mail
    {
        public static bool SendMail(string from, string to, string subjct, string body)
        {
            bool isSent = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subjct;
                mail.Body = body;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("amit49499@mail.com", "8109170818g");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                isSent = true;
            }
            catch (Exception ex)
            {
                isSent = false;
            }
            return isSent;
        }

    }
}
