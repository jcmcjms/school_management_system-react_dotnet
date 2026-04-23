namespace Application.DTOs.Common;

public class PaginationParams
{
    private const int MaxPageSize = 100;
    private int _pageSize = 20;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }

    public string? SortBy { get; set; }
    public string? SortOrder { get; set; } = "asc";
    public string? Search { get; set; }
    public Dictionary<string, string>? Filters { get; set; }
}