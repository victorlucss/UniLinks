﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using UniLink.API.Services.Email.Interfaces;

namespace UniLink.API.Services.Email
{
    public class SendEmailService : ISendEmailService
    {
        private readonly ConfigEmailModel _configEmail;

        public SendEmailService(IOptions<ConfigEmailModel> configEmail) => _configEmail = configEmail.Value;

        public static string EmailTemplate { get; private set; }

        static SendEmailService() => ReadEmailTemplateTaskAsync();

        /// <summary>
        /// Faz o envio do email avisando que a conta do aluno foi ativada
        /// </summary>
        /// <param name="email">Email do usuario</param>
        public async Task<bool> SendEmailTaskAsync(string email)
        {
            try
            {
                var mail = new MailMessage()
                {
                    From = new MailAddress(_configEmail.Email, "UniLink"),
                    Subject = "UniLink - Ativação da conta",
                    Body = EmailTemplate.ToString(),
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(email));

                using var smtp = new SmtpClient(_configEmail.Domain, _configEmail.Port)
                {
                    Credentials = new NetworkCredential(_configEmail.Email, _configEmail.Password),
                    EnableSsl = true
                };
                await smtp.SendMailAsync(mail);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async void ReadEmailTemplateTaskAsync()
        {
            //using Task<string> fs = File.ReadAllTextAsync(@"C:\RecoverAccountEmailTemplate.html");
            EmailTemplate = "<html><h1>Conta Ativada</h1></html>";
        }
    }
}