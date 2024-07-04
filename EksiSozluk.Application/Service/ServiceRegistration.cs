using Microsoft.Extensions.DependencyInjection;

namespace EksiSozluk.Application.Service
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        }
        //service extension 
    }
}
