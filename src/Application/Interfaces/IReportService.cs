namespace Application.Interfaces;

public interface IReportService
{
    Task<byte[]> GetSalesReportAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    Task<byte[]> GetPopularItemsReportAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    Task<byte[]> GetRevenueByTimeOfDayAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    Task<byte[]> GetStudentConsumptionReportAsync(Guid studentId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    Task<byte[]> ExportToExcelAsync<T>(List<T> data, string sheetName, CancellationToken cancellationToken = default);
    Task<byte[]> ExportToPdfAsync<T>(List<T> data, string title, CancellationToken cancellationToken = default);
}