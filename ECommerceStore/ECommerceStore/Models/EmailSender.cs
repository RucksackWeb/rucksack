using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace ECommerceStore.Models
{
    public class EmailSender : IEmailSender
    {

        public IConfiguration Configuration {get; private set;}
        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(Configuration["SendGrid"]);

            var msg = new SendGridMessage();

            msg.SetFrom("customerservice@rucksack.com", "RuckSack Customer Service");

            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, htmlMessage);

            var response = await client.SendEmailAsync(msg);
        }
    }
}
