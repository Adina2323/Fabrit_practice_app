using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager
{
    //The methods for sending emails are not working. I searched online and understood that it's because of the access to the account for third-party applications, but it doesn't let me deactivate it. "To keep your account secure, starting from May 30, 2022, Google will no longer allow the use of third-party apps or devices that ask you to log into your Google Account using only the username and password." I added some displays to simulate a bit how it would have been if it were working.
    /// <summary>
    /// Class <c>EmailNotificationsService</c> that handles the methods for email sending
    /// </summary>
    internal class EmailNotificationService
    {
        /// <summary>
        /// A Method for sending emails of sign up confirmation
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true if the email was sent, false otherwise</returns>
        public bool SendSignUpConfirmation(string email)
        {
            /*
            var smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("mockmockmock387@gmail.com", "PassWord1");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            var mailMessage = new MailMessage()
            {
                From = new MailAddress(email),
                Subject = "Confirmation email!",
                Body = "<h1>Hello</h1>",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(email);
            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine($"Email sent to: {email}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            */
            Console.WriteLine($"\nYour account has been created {email}.\n");
            return true;

        }


        /// <summary>
        ///  A Method for sending emails of new user info after update. 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool SendUserInfoEmail(string email)
        {
            /*
            var smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("mockmockmock387@gmail.com", "PassWord1");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            var mailMessage = new MailMessage()
            {
                From = new MailAddress(email),
                Subject = "Account details updated!",
                Body = "<p>Your account details have been successfully updated.</p>",
                IsBodyHtml = true,

            };
            mailMessage.To.Add(email);
            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine($"Email was sent to: {email}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            */

            Console.WriteLine($"\nYour account details have been successfully updated: {email}.\n");
            return true;
        }

    }
}
