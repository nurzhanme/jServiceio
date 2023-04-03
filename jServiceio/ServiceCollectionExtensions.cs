using jServiceio.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jServiceio;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJServiceioClient(this IServiceCollection services)
    {
        services.AddOptions<JServiceioOptions>();
        AddHttpClientWithHandlers(services);
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        services.Configure<JServiceioOptions>(configuration.GetSection(nameof(JServiceioOptions)));
        return services;
    }

    public static IServiceCollection AddJServiceioClient(this IServiceCollection services, Action<JServiceioOptions> setupAction)
    {
        services.AddOptions<JServiceioOptions>().Configure(setupAction);
        AddHttpClientWithHandlers(services);
        return services;
    }

    private static void AddHttpClientWithHandlers(IServiceCollection services)
    {
        services
            .AddScoped<LoggingHandler>()
            .AddScoped<ExceptionHandler>();

        services
            .AddHttpClient<JServiceioClient>()
            .AddHttpMessageHandler<LoggingHandler>()
            .AddHttpMessageHandler<ExceptionHandler>();
    }
}