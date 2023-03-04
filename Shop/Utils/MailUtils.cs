using System;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Shop.SendMail
{
    public class MailUtils
    {



        /// <summary>
        /// Gửi email sử dụng máy chủ SMTP Google (smtp.gmail.com)
        /// </summary>
        public static async Task<String> SendMailGoogleSmtp(string _to, string _subject, string _body)
        {
            string senderEmail = "phihung3399@gmail.com";
            string senderPassword = "zovjvewhxfocavmp";
            MailMessage message = new MailMessage(
                from: senderEmail,
                to: _to,
                subject: _subject,
                body: _body
            );
            message.Sender = new MailAddress(senderEmail);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                client.EnableSsl = true;
                try
                {
                    await client.SendMailAsync(message);
                    Console.WriteLine("Ok");
                    return "Gui mail thanh cong";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "Gui mail that bai";
                }
            }

        }
    }
}
