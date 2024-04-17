using EksiSozluk.WebUI.Services;

namespace EksiSozluk.WebUI.Extensions
{
    public static class DIExtension
    {
        public static void AddDI(this IServiceCollection services)
        {
            services.AddScoped<HttpClientServiceViewComponent>();
            services.AddScoped<HttpClientServiceAction>();
        }
    }
}
