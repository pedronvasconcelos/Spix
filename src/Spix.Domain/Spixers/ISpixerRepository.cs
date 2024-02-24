 
namespace Spix.Domain.Spixers;

public interface ISpixerRepository
{
    public Task<Spixer> AddAsync(Spixer spixer);
    public Task<Spixer> GetAsync(Guid id);
}
