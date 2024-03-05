using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spix.Domain.SeedOfWork;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    Task<T?> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    IUnitOfWork UnitOfWork { get; }
}
