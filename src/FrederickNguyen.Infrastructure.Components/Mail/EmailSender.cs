// ***********************************************************************
// Assembly         : FrederickNguyen.Infrastructure
// Author           : thangnd
// Created          : 07-09-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-09-2018
// ***********************************************************************
// <copyright file="EmailSender.cs" company="FrederickNguyen.Infrastructure">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FrederickNguyen.Infrastructure.Components.Mail
{
    /// <summary>
    /// Class EmailSender.
    /// </summary>
    public class EmailSender : IEmailSender
    {
        private readonly string _sendGridKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSender" /> class.
        /// </summary>
        public EmailSender()
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _sendGridKey = config["SendGridKey"];
        }

        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(_sendGridKey, subject, message, email);
        }

        /// <summary>
        /// Executes the specified API key.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <param name="email">The email.</param>
        /// <returns>Task.</returns>
        private static Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                // should be a domain other than yahoo.com, outlook.com, hotmail.com, gmail.com
                From = new EmailAddress("mail@domain.com", subject),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            //var response = await client.SendEmailAsync(msg);
            return client.SendEmailAsync(msg);
        }
    }
}
