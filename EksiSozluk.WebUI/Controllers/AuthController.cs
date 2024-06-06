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
            var response = await _httpClientServiceAction.CreateAsyncVal<RegisterDto>("Auths/register", registerDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SignIn", "Auth");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var validationErrors = JsonSerializer.Deserialize<ValidationProblemDetails>(errorContent);
                if (validationErrors != null)
                {
                    foreach (var error in validationErrors.Errors)
                    {
                        ModelState.AddModelError(error.Key, string.Join(" ", error.Value));
                    }
                }
                return View(registerDto);
            }
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
                        claims.Add(new Claim("acisozluktoken", tokenModel.Message));
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
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var validationErrors = JsonSerializer.Deserialize<ValidationProblemDetails>(errorContent);
                if (validationErrors != null)
                {
                    foreach (var error in validationErrors.Errors)
                    {
                        ModelState.AddModelError(error.Key, string.Join(" ", error.Value));
                    }
                }
            }

            return View(loginDto);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
