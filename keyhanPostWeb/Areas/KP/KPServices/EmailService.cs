
using keyhanPostWeb.GeneralService;
using keyhanPostWeb.GeneralViewModels.RepDto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.KP.KPservices
{
    public static class EmailService
    {
        public static void Send(
            string to,
            string subject,
            string body,
            List<string> ccList = null,
            List<string> bccList = null,
            List<string> attachments = null,
            string fromName = "کانال ارتباطی وب سایت کیهان پست")
        {
            var password = "Keyhan@web";
            var myMail = "keyhanpostwebsite@gmail.com";

            using (var mail = new MailMessage())
            {
                // تنظیمات اصلی ایمیل
                mail.From = new MailAddress(myMail, fromName);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                // افزودن گیرنده اصلی
                mail.To.Add(to);

                // افزودن گیرندگان کپی (در صورت موجود بودن)
                if (ccList != null)
                {
                    foreach (var cc in ccList)
                    {
                        mail.CC.Add(cc);
                    }
                }

                // افزودن گیرندگان کپی مخفی (در صورت موجود بودن)
                if (bccList != null)
                {
                    foreach (var bcc in bccList)
                    {
                        mail.Bcc.Add(bcc);
                    }
                }

                // افزودن پیوست‌ها (در صورت موجود بودن)
                if (attachments != null)
                {
                    foreach (var attachmentPath in attachments)
                    {
                        if (File.Exists(attachmentPath))
                        {
                            mail.Attachments.Add(new Attachment(attachmentPath));
                        }
                        else
                        {
                            Console.WriteLine($"پیوست یافت نشد: {attachmentPath}");
                        }
                    }
                }

                // تنظیمات SMTP
                using (var smtpServer = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpServer.EnableSsl = true;
                    smtpServer.UseDefaultCredentials = false;
                    smtpServer.Credentials = new NetworkCredential(myMail, password);

                    try
                    {
                        smtpServer.Send(mail);
                        Console.WriteLine("ایمیل با موفقیت ارسال شد.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("خطا در ارسال ایمیل: " + ex.Message);
                    }
                }
            }
        }


        public static async Task SendByHRAsync(string to, string subject, string body)
        {
            var password = "Keyhan@Post@";
            var myMail = "hr@keyhanpost.ir";

            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress(myMail, " منابع انسانی کیهان پست");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (var smtpServer = new SmtpClient("mail.keyhanpost.ir", 25))
                {
                    smtpServer.UseDefaultCredentials = false;
                    smtpServer.Credentials = new NetworkCredential(myMail, password);
                    smtpServer.EnableSsl = false; // تغییر به true در صورت نیاز به SSL

                    try
                    {
                        await smtpServer.SendMailAsync(mail);
                        Console.WriteLine("ایمیل با موفقیت ارسال شد.");
                    }
                    catch (SmtpFailedRecipientsException ex)
                    {
                        Console.WriteLine("خطا در ارسال ایمیل به برخی گیرندگان: " + ex.Message);
                        foreach (var innerEx in ex.InnerExceptions)
                        {
                            Console.WriteLine($"خطا برای گیرنده {innerEx.FailedRecipient}: {innerEx.Message}");
                        }
                    }
                    catch (SmtpException ex)
                    {
                        Console.WriteLine("خطای SMTP: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("خطا در ارسال ایمیل: " + ex.Message);
                    }
                }
            }
        }

        public static async Task SendByAvaAsync(string to, string subject, string body, List<string> ccList = null,
            List<string> bccList = null)
        {
            var password = "aonx jurj gitu rhma";
            var myMail = "avaandish.sup@gmail.com";
            var mail = new MailMessage(myMail, to);
            var smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(myMail, "منابع انسانی کیهان پست");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            // افزودن گیرندگان کپی (در صورت موجود بودن)
            if (ccList != null)
            {
                foreach (var cc in ccList)
                {
                    mail.CC.Add(cc);
                }
            }

            // افزودن گیرندگان کپی مخفی (در صورت موجود بودن)
            if (bccList != null)
            {
                foreach (var bcc in bccList)
                {
                    mail.Bcc.Add(bcc);
                }
            }
            smtpServer.Port = 587;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new NetworkCredential(myMail, password);
            smtpServer.EnableSsl = true;
            smtpServer.Timeout = 1000000;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

            await smtpServer.SendMailAsync(mail);
        }

        public static string GenerateEmailBody(RepApplicantDetailDto model)
        {
            return $@"
<html dir='rtl' lang='fa'>
<head>
    <meta charset='UTF-8'>
    <title>{model.CityName} - {model.ApplicantName}</title>
</head>
<body style='font-family: Yekan, sans-serif; direction: rtl; background-color: #f3f4f6; color: #333; margin: 0; padding: 0;'>
    <div style='max-width: 800px; margin: 0 auto; padding: 20px; background-color: white; border-radius: 8px; border: 1px solid #ddd;'>
        <h2 style='text-align: center; color: #333; font-size: 1.6rem; margin-bottom: 20px;'>{model.CityName} - {model.ApplicantName}</h2>
        <table id='info-table' style='width: 100%; border-collapse: collapse; font-size: 14px;'>
            <tr>
                <th style='padding: 10px; border: 1px solid #ddd; background-color: #f7f7f7; font-weight: bold;'>عنوان</th>
                <th style='padding: 10px; border: 1px solid #ddd; background-color: #f7f7f7; font-weight: bold;'>اطلاعات</th>
                <th style='padding: 10px; border: 1px solid #ddd; background-color: #f7f7f7; font-weight: bold;'>امتیاز</th>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>تاریخ ثبت</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.RequestDate.LatinToPersian()}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>-</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>شماره پیگیری</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.TrackingNumber}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>-</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>نام متقاضی</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.ApplicantName}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>-</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>نام کاربری</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.Username}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>-</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>شماره موبایل</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.MobileNumber}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>-</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>آدرس ایمیل</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.Email}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>-</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>شناسه ملی</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.NationalId}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>-</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>آدرس</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.Address}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>-</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>نوع نمایندگی</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.AgencyType}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.AgencyType_Score}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>میزان تحصیلات</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.EducationDegree}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.EducationDegree_Score}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>سابقه فعالیت</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.Experience}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.Experience_Score}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>نوع شخصیت</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.EntityType}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>-</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>وضعیت وسیله نقلیه</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.VehicleAvailability}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.VehicleAvailability_Score}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>نوع خودرو</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.VehicleType}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>-</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>شهر محل فعالیت</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.CityName}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>-</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>وضعیت مالکیت ملک</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.PropertyType}</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{model.PropertyType_Score}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd;'>سابر توضیحات متقاضی</td>
                <td colspam='2' style='padding: 10px; border: 1px solid #ddd;'>{model.OtherDesc}</td>
               
            </tr>
            <tr>
                <th style='padding: 10px; border: 1px solid #ddd; background-color: #f7f7f7; font-weight: bold;' colspan='2'>جمع کل امتیاز</th>
                <th style='padding: 10px; border: 1px solid #ddd; background-color: #f7f7f7; font-weight: bold;'>{(model.AgencyType_Score ?? 0) + (model.EducationDegree_Score ?? 0) + (model.Experience_Score ?? 0) + (model.VehicleAvailability_Score ?? 0) + (model.PropertyType_Score ?? 0)}</th>
            </tr>
        </table>
        <div style='margin-top:25px;'>
        <a href='tel:{model.MobileNumber}' style='width: 100px; padding:10px 20px; margin: 20px 10px; text-align: center; background-color: #4CAF50; color: white; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;'>تماس با متقاضی</a>
        <a href='https://keyhanpost.ir/Home/PrintJobRequest/{model.Id}' target='_blank'  style=' width: 100px; padding:10px 40px; margin: 20px 10px; text-align: center; background-color: #4CAF50; color: white; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;'>مشاهده </a>
        </div>
    </div>
    <script>
        function printTable() {{
            var originalContents = document.body.innerHTML;
            var printContents = document.getElementById('info-table').outerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
        }}
    </script>
</body>
</html>";
        }





        public static async Task SendRepApplicantDetails(RepApplicantDetailDto model, string recipientEmail, List<string> CcList = null)
        {
            string subject = $"در خواست همکاری - {model.CityName}";
            string body = GenerateEmailBody(model);

            await SendByAvaAsync(
                  to: recipientEmail,
                  subject: subject,
                  body: body,
                  ccList: CcList
              );
        }

    }
}
