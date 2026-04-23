using Application.DTOs.Auth;
using Application.DTOs.Common;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
    Task<Result<AuthResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    Task<Result<AuthResponse>> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken = default);
    Task<Result<bool>> ChangePasswordAsync(Guid userId, ChangePasswordRequest request, CancellationToken cancellationToken = default);
    Task<Result<bool>> ForgotPasswordAsync(string email, CancellationToken cancellationToken = default);
    Task<Result<bool>> ResetPasswordAsync(string email, string token, string newPassword, CancellationToken cancellationToken = default);
}