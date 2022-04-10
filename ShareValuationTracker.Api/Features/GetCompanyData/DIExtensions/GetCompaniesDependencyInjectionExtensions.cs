namespace Placeholder.API.Features.GetCompanyData.DIExtensions
{
    public static class GetCompaniesDependencyInjectionExtensions
    {
        public static IServiceCollection AddGetCompaniesFeature(this IServiceCollection services)
        {
            services.AddScoped<ICompanyDataProvider, CompanyDataProvider>();

            return services;
        }
    }
}
