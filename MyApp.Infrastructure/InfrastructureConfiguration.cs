using Clean.Architecture.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Domain.ProjectAggregate;
using MyApp.Infrastructure.DataAccess;
using MyApp.Infrastructure.EmailProvider;

namespace MyApp.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection serviceCollection)
    {

        serviceCollection.AddSingleton<IEmailSender, MailJetEmailProvider>();
        serviceCollection.AddScoped<IProjectRepository, EfProjectRepository>();
        
        return serviceCollection;
    }
}