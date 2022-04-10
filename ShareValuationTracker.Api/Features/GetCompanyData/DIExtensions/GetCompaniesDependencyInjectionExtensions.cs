using ShareValuationTracker.Api.Features.GetCompanyData;

namespace Placeholder.API.Features.GetCompanyData.DIExtensions
{
    public static class GetCompaniesDependencyInjectionExtensions
    {
        public static IServiceCollection AddGetCompaniesFeature(this IServiceCollection services)
        {
            services.AddScoped<IYahooFinanceDataSelector, YahooFinanceDataSelector>();
            services.AddScoped<ICompanyDataSelector, CompanyDataSelector>();

            return services;
        }
    }
}
