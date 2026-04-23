using Domain.Common;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Interfaces;

public interface IUnitOfWork: IDisposable
{
    IRepository<T> GetRepository<T>() where T: BaseEntity;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}