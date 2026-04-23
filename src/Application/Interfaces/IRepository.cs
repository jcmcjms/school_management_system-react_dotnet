using System.Linq.Expressions;
using Domain.Common;

namespace Application.Interfaces;

public interface IRepository<T> where T: BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
    Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    Task<T> AddAsync(T entity);
    Task UpateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task HardDeleteAsync(Guid id);
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);
    Task<bool> ExistsAsync(Guid id);
    Task<PagedResult<T>> GetPagedAsync(PaginationParams parameters, params Expression<Func<T, object>>[] includes);
}

public class PaginationParams
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; }
    public string? SortOrder { get; set; } = "asc";
    public string? Search { get; set; }
    public Dictionary<string, string>? Filters { get; set; }
}

public class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; set; } = new List<T>();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPrevious => PageNumber > 1;
    public bool HasNext => PageNumber < TotalPages;
}