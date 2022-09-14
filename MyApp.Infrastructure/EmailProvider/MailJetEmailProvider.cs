using Clean.Architecture.Core.Interfaces;

namespace MyApp.Infrastructure.EmailProvider;

public class MailJetEmailProvider : IEmailSender
{
    public async Task SendEmailAsync(string to, string @from, string subject, string body)
    {
        throw new NotImplementedException();
    }
}