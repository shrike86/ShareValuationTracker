using Placeholder.API.Services.Yahoo;

namespace Placeholder.API.Services.YahooFinance.DIExtensions
{
    public static class YahooFinanceServiceDependencyInjectionExtensions
    {
        public static IServiceCollection AddYahooFinanceClient(this IServiceCollection services)
        {
            services.AddScoped<IYahooFinanceService, YahooFinanceService>();
            services.AddScoped<IEndpointUtility, EndpointUtility>();

            return services;
        }
    }
}
