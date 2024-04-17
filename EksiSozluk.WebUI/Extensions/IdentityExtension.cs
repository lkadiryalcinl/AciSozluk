using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EksiSozluk.WebUI.Extensions
{
    public static class IdentityExtension
    {
        public static void AddJwtBearerEx(this IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.LoginPath = "/Auth/Login/";
                opt.LogoutPath = "/Home/Index/";
                opt.AccessDeniedPath = "/Pages/AccessDenied/";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.Cookie.Name = "EksiSozlukJwt";
            });
        }
    }
}
