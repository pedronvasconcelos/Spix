namespace Spix.Domain.Core.SeedOfWork;

public interface IUnitOfWork
{
    Task<bool> CommitAsync(CancellationToken cancellationToken = default);
}
