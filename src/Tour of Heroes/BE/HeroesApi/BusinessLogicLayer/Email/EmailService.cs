using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using MailKit;
using Microsoft.Extensions.Configuration;
using MimeKit;
using DataAcessLayer.Mappings.DTOs;
using BusinessLogicLayer.Configuration;

namespace BusinessLogicLayer.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailService( EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
        public async Task SendEmailAsync(InviteMailDTO inviteMailDTO)
        {
            var mailMessage = CreateEmailMessage(inviteMailDTO);

            await SendAsync(mailMessage);
        }
        public MimeMessage CreateEmailMessage(InviteMailDTO inviteMailDTO)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfiguration.UserName, _emailConfiguration.From));
            emailMessage.To.Add(new MailboxAddress(inviteMailDTO.ReceiverName, inviteMailDTO.EmailTo));
            emailMessage.Subject = inviteMailDTO.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", inviteMailDTO.Body) };

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfiguration.UserName, _emailConfiguration.Password);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
