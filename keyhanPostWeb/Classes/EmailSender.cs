using keyhanPostWeb.Areas.CMS.Dtos;
using System.Net;
using System.Net.Mail;

namespace keyhanPostWeb.Classes
{

    public static class EmailSender
    {
        public static void Send(string to, string subject, string body)
        {
            var password = "Keyhan@web";
            var myMail = "keyhanpostwebsite@gmail.com";
            var mail = new MailMessage(myMail, to);
            var smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(myMail, "کانال ارتباطی وب سایت کیهان پست");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            smtpServer.Port = 587;
            smtpServer.EnableSsl = false;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new NetworkCredential(myMail, password);
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);
        }

        public static void SendByHR(string to, string subject, string body)
        {
            var password = "Keyhan@Post@";
            var myMail = "hr.keyhanpost.ir";
            var mail = new MailMessage(myMail, to);
            var smtpServer = new SmtpClient("mail.keyhanpost.ir");

            mail.From = new MailAddress(myMail, "کانال ارتباطی وب سایت کیهان پست");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            smtpServer.Port = 25;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new NetworkCredential(myMail, password);

            smtpServer.Send(mail);
        }
        public static void SendByKeyhanpost(SendEmailDto em)
        {
            string emailBody = $@"
            <html>
                <body>
                    <div style='font-family:Tahoma; background-color:whitesmoke;  direction:rtl; text-align:right; margin:15px; padding:15px; border-radius:8px; border:1px dashed;' >
                            <div style='margin-right:20px;'>
                                <h3 style='color:green;'>موضوع: {em.EmailSubject}</h3>
                                <div>
                                    <h4 style=' margin-top:0; margin-bottom: 10px;'>فرستنده: {em.SenderFullName}</h4>
                                    <h5 style=' margin-top:0; margin-bottom: 10px;'>شماره تماس فرستنده: {em.Mobile}</h5>
                                    <h5 style=' margin-top:0;'>ایمیل فرستنده: {em.EmailFrom}</h5>
                                </div>
                            </div>
                    
                        <div style='margin:25px; padding:20px; background-color:white; border-radius:8px; box-shadow:0 0 3px #ccc;'>
                            <p style='font-family:Tahoma; line-height: 25px;'>{em.EmailBody.Replace("\n", "<br>")}</p>
                        </div>
                    </div>
                </body>
            </html>
             ";

            var password = "5?96c5lPg";
            var myMail = "websitechanel@keyhanpost.ir";
            var mail = new MailMessage(myMail, em.EmailTo);
            var smtpServer = new SmtpClient("mail.keyhanpost.ir");

            mail.From = new MailAddress(myMail, "کانال ارتباطی وب سایت کیهان پست");
            mail.To.Add(em.EmailTo);
            mail.Subject = em.EmailSubject;
            mail.Body = emailBody;
            mail.IsBodyHtml = true;
            smtpServer.Port = 25;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new NetworkCredential(myMail, password);

            smtpServer.Send(mail);
        }

    }
}
