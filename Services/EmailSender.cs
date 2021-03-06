﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CRM.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {       
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("pdavisson@kw.com", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            msg.SetTemplateId("d-d5189e1fbbc1459aadeb9049cc0844fe");
            msg.SetTemplateData(new ButtonURL
            {
                ConfirmURL=message
            });
            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            
            return client.SendEmailAsync(msg);
            
        }
            private class ButtonURL
            {
                [JsonProperty("ConfirmURL")]
                public string ConfirmURL { get; set; }
            }
    
    
    //ORIGINAL FROM HERE DOWN, EVERYTHING ABOVE THIS AND BELOW PUBLIC CLASS EMAILSENDER : IEMAILSENDER CAN BE DELETED TO REVERT BACK TO START
        // public Task SendEmailAsync(string email, string subject, string message)
        // {
        //     return Task.CompletedTask;
        // }
    }
}
