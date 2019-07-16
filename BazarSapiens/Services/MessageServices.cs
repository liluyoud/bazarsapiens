using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Services
{
    public interface IMessageServices
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
        Task SendModeloEmailAsync(string email, string modelo, params string[] args);
    }

    public class MessageServices : IMessageServices
    {
        private readonly IHostingEnvironment env;
        private readonly ILogger<MessageServices> logger;


        public MessageServices(IHostingEnvironment env, ILogger<MessageServices> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Bazar da Solidariedade", "bazar.solidariedade.ro@gmail.com"));
            message.To.Add(new MailboxAddress(email));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = htmlMessage };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("bazar.solidariedade.ro@gmail.com", "Bazar@123");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }

        public async Task SendModeloEmailAsync(string email, string modelo, params string[] args)
        {
            var diretorio = Path.Combine(env.WebRootPath, "emails");
            var arquivo = Path.Combine(diretorio, modelo + ".html");
            StreamReader leitor = File.OpenText(arquivo);
            string conteudo = leitor.ReadToEnd();
            if (args.Length > 0)
                conteudo = string.Format(conteudo, args);
            string assunto = conteudo.Substring(0, conteudo.IndexOf("\n"));
            string mensagem = conteudo.Substring(conteudo.IndexOf("\n") + 1);
            leitor.Close();

            await SendEmailAsync(email, assunto, mensagem);
        }
    }
}
