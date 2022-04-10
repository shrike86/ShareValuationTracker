namespace Placeholder.API.Adapters.DIExtensions
{
    public static class AdapterDependencyInjectionExtensions
    {
        public static IServiceCollection AddAdapters(this IServiceCollection services)
        {
            services.AddScoped<IJsonConvert, JsonConvertAdapter>();

            return services;
        }
    }
}
