using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EksiSozluk.Application.Service
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        }
    }
}
