using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
namespace EasieR.Implementation.Email
{
    public class EmailService
    {
        private readonly MailKitEmailSenderOptions _appSettings;
        public EmailService()
        {
        }
        public EmailService(IOptions<MailKitEmailSenderOptions> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void Send(string from, string to, string subject, string html)
        {
            /*          try
                      {
                          var configuration = new Configuration();
                          if (!Configuration.Default.ApiKey.ContainsKey("api-key"))
                          {
                              Configuration.Default.ApiKey.Add("api-key", "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");
                          }
                          configuration.ApiKey.Add("api-key", "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");
                          var apiInstance = new TransactionalEmailsApi();
                          apiInstance.Configuration = configuration;
                          var sendSmtpEmail = new SendSmtpEmail();
                          List<SendSmtpEmailTo> sendSmtpEmailTos = new List<SendSmtpEmailTo>();
                          SendSmtpEmailTo sendSmtpEmailTo = new SendSmtpEmailTo(to, "Aleksandar Radovanovic");
                          sendSmtpEmailTos.Add(sendSmtpEmailTo);
                          sendSmtpEmail.Sender = new SendSmtpEmailSender("Aleksandar Radovanovic", from);
                          sendSmtpEmail.To = sendSmtpEmailTos;
                          sendSmtpEmail.Subject = "Test";
                          sendSmtpEmail.TextContent = "Test text";
                          CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                      }
                      catch (Exception ex)
                      {

                          throw ex;
                      }*/
            // create message
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(from));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = html };


                // send email
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, new SecureSocketOptions());
                //smtp.Authenticate("acaca93@gmail.com", "62290922");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }
    }
}
