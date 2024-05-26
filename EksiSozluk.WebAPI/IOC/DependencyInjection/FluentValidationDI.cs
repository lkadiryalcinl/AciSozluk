using EksiSozluk.Application.Dtos.AuthDtos;
using EksiSozluk.WebAPI.Validators.AuthValidators;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace EksiSozluk.WebAPI.IOC.DependencyInjection
{
    public static class FluentValidationDI
    {
        public static void AddValidatorsDI(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RegisterDto>, RegisterValidator>();
            services.AddTransient<IValidator<LoginDto>, LoginValidator>();
        }

        public static void AddFluentValidationDI(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation();
        }
    }
}
