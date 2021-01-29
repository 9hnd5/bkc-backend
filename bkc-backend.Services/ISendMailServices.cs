using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace bkc_backend.Services
{
    public class MailContent
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> CCTos { get; set; }
    }
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
    public interface ISendMailServices
    {
        public Task SendMail(MailContent mailContent);
    }
    public class SendMailServices : ISendMailServices
    {
        private readonly MailSettings _mailSettings;
        public SendMailServices(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;
            var coppies = new List<MailboxAddress>();
            if (mailContent.CCTos != null)
            {

                foreach (var ccTo in mailContent.CCTos)
                {
                    coppies.Add(new MailboxAddress(_mailSettings.DisplayName, ccTo));
                }
            }
            email.Cc.AddRange(coppies);
            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();

            var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                System.IO.Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                email.WriteTo(emailsavefile);
            }

            smtp.Disconnect(true);
        }
    }
}
