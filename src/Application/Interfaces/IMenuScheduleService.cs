using Application.DTOs.Canteen;
using Application.DTOs.Common;

namespace Application.Interfaces;

public interface IMenuScheduleService
{
    Task<Result<bool>> CreateWeeklyMenuAsync(WeeklyMenuRequest request, Guid createdBy, CancellationToken cancellationToken = default);
    Task<PagedResult<MenuScheduleDto>> GetWeeklyMenuAsync(DateOnly weekStart, CancellationToken cancellationToken = default);
    Task<Result<bool>> ApproveWeeklyMenuAsync(Guid scheduleId, Guid approvedBy, CancellationToken cancellationToken = default);
    Task<PagedResult<MenuScheduleDto>> GetTodayMenuAsync(CancellationToken cancellationToken = default);
}