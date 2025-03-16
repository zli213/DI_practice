using ConfigService;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;

namespace MailSender;

class Program
{
    static void Main(string[] args)
    {
        ServiceCollection services = new ServiceCollection();
        // services.AddScoped<IConfigService, EnvVarConfigService>();
        // services.AddScoped<IConfigService>(provider => new IniFileConfigService { FilePath = "mail.ini" });
        services.AddScoped(typeof(IConfigService), s => new IniFileConfigService { FilePath = "mail.ini" });
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<ILogProvider, ConsoleLogProvider>();
        using (var sp = services.BuildServiceProvider())
        {
            var mailService = sp.GetRequiredService<IMailService>();
            mailService.Send("Hello", "test@example.com", "Hello world");
        }
        Console.Read();
    }
}

