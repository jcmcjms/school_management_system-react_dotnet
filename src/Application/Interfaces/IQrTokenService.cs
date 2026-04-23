using Application.DTOs.Common;

namespace Application.Interfaces;

public interface IQrTokenService
{
    Task<Result<string>> GenerateTokenAsync(Guid orderId, CancellationToken cancellationToken = default);
    Task<Result<bool>> VerifyTokenAsync(string token, CancellationToken cancellationToken = default);
    Task<Result<bool>> InvalidateTokenAsync(Guid orderId, CancellationToken cancellationToken = default);
}