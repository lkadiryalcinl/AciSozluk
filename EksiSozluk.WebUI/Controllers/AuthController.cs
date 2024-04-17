using EksiSozluk.WebUI.Dto.AuthDtos;
using EksiSozluk.WebUI.Models;
using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace EksiSozluk.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public AuthController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (registerDto.Password == registerDto.PasswordAgain && registerDto.isAggrCheck==true)
            {
                var isSucceded = await _httpClientServiceAction.CreateAsync<RegisterDto>("Auths/register", registerDto);
                return isSucceded ? RedirectToAction("SignIn", "Auth") : View();
            }
            return View();
        }



        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            var response = await _httpClientServiceAction.CreateAsyncVal<LoginDto>("Auths/login", loginDto);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<AuthServiceResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new();
                    var token = handler.ReadJwtToken(tokenModel.Message);
                    var claims = token.Claims.ToList();

                    if (tokenModel.Message != null)
                    {
                        claims.Add(new Claim("carbooktoken", tokenModel.Message));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = token.ValidTo,
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
