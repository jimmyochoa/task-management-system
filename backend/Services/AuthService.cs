using System;
using System.Linq;
using System.Threading.Tasks; // Asegúrate de agregar esto
using backend.DTOs;
using backend.Helpers;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly TaskSystemContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(TaskSystemContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponseDTO> Register(RegisterRequestDto registerDto)
        {
            // Check if user already exists
            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
            {
                return new AuthResponseDTO
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            // Hash the password
            var hashedPassword = HashHelper.HashPassword(registerDto.Password);

            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Password = hashedPassword,
                ProfilePhotoLoc = string.Empty,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            await _context.Users.AddAsync(user); // Asynchronous add
            await _context.SaveChangesAsync(); // Asynchronous save

            var token = JwtHelper.GenerateJwtToken(user, _configuration);

            return new AuthResponseDTO
            {
                Success = true,
                Message = "User registered successfully.",
                Token = token
            };
        }

        public async Task<AuthResponseDTO> Login(LoginRequestDto loginDto)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Email == loginDto.Email); // Asynchronous query

            if (user == null || !HashHelper.VerifyPassword(loginDto.Password, user.Password))
            {
                return new AuthResponseDTO
                {
                    Success = false,
                    Message = "Invalid credentials."
                };
            }

            var token = JwtHelper.GenerateJwtToken(user, _configuration);

            return new AuthResponseDTO
            {
                Success = true,
                Message = "Login successful.",
                Token = token
            };
        }
    }
}
