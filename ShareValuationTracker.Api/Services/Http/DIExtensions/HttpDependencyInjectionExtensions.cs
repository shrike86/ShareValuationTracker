namespace Placeholder.API.Services.Http.DIExtensions
{
    public static class HttpDependencyInjectionExtensions
    {
        public static IServiceCollection AddHttp(this IServiceCollection services)
        {
            services.AddScoped<IBaseHttpService, BaseHttpService>();
            services.AddScoped<IHttpResponseMessageParser, HttpResponseMessageParser>();
            services.AddScoped<IHttpResponseMessageWrapper, HttpResponseMessageWrapper>();

            return services;
        }
    }
}
