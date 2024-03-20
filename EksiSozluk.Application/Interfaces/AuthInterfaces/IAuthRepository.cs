using EksiSozluk.Application.Dtos.AuthDtos;

namespace EksiSozluk.Application.Interfaces.AuthInterfaces
{
    public interface IAuthRepository
    {
        Task<AuthServiceResponseDto> SeedRolesAsync();
        Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto);
        Task<AuthServiceResponseDto> MakeAuthorAsync(UpdatePermissionDto updatePermissionDto);
        Task<AuthServiceResponseDto> RegisterAsync(RegisterDto registerDto);
   
    }
}
