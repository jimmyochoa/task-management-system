using backend.DTOs;

namespace backend.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> Register(RegisterRequestDto registerDto);

        Task<AuthResponseDTO> Login(LoginRequestDto loginDto);
    }
}
