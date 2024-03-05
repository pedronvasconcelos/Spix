namespace Spix.Domain.SeedOfWork;

public interface IUnitOfWork
{
    Task<bool> CommitAsync(CancellationToken cancellationToken = default);  
}
