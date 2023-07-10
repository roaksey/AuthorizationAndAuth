
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace IdentityManager.Service
{
    public class MailJetEmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        public MailJetOptions mailJetOptions;
        public MailJetEmailSender(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            mailJetOptions = _config.GetSection("MailJet").Get<MailJetOptions>();
            MailjetClient client = new MailjetClient(mailJetOptions.ApiKey, mailJetOptions.SecretKey);
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
     new JObject {
      {
       "From",
       new JObject {
        {"Email", "roaksey@proton.me"},
        {"Name", "Rajeev"}
       }
      }, {
       "To",
       new JArray {
        new JObject {
         {
          "Email",
          "roaksey@proton.me"
         }, {
          "Name",
          "Rajeev"
         }
        }
       }
      }, {
       "Subject",
       subject
      }, {
       "TextPart",
       htmlMessage
      }, {
       "HTMLPart",
       "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
      }, {
       "CustomID",
       "AppGettingStartedTest"
      }
     }
             });
         await client.PostAsync(request);
            //if (response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
            //    Console.WriteLine(response.GetData());
            //}
            //else
            //{
            //    Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
            //    Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
            //    Console.WriteLine(response.GetData());
            //    Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            //}
        }
    }
}
