using System;
using ConfigService;
using LogServices;

namespace MailServices
{
	public class MailService : IMailService
    {
		private readonly ILogProvider log;
		private readonly IConfigService config;

		public MailService(ILogProvider log, IConfigService config)
		{
			this.log = log;
			this.config = config;
		}
		public void Send(string title, string to, string body)
		{
			this.log.LogInfo("Prepare to send an Email!");
			string smtpServer = this.config.GetValue("SmtpServer");
            string userName = this.config.GetValue("UserName");
            string password = this.config.GetValue("Password");
			Console.WriteLine($"Email Server address{smtpServer}, userName: {userName}, password: {password}");
            Console.WriteLine($"Title: {title} {to}, content body is: {body}, has been sent!");
			this.log.LogInfo("Done!");
        }
	}
}

