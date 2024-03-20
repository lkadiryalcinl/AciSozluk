using EksiSozluk.Application.Dtos.AuthDtos;
using Microsoft.AspNetCore.Mvc;
using EksiSozluk.Application.Interfaces.AuthInterfaces;

namespace EksiSozluk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        //Route for Seeding My roles to Db
        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seedRoles = await _authRepository.SeedRolesAsync();
            return Ok(seedRoles);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var registerResult = await _authRepository.RegisterAsync(registerDto);

            if (registerResult.IsSucceed)
                return Ok(registerResult);

            return BadRequest(registerResult);
        }

        //Route ---> login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var loginResult = await _authRepository.LoginAsync(loginDto);
            if (loginResult.IsSucceed)
                return Ok(loginResult);
            return Unauthorized(loginResult);
        }

        //Route ---> make-author
        [HttpPost]
        [Route("make-author")]
        public async Task<IActionResult> MakeAuthor([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var operationResult = await _authRepository.MakeAuthorAsync(updatePermissionDto);

            if (operationResult.IsSucceed)
                return Ok(operationResult);

            return BadRequest(operationResult);
        }

    }
}
