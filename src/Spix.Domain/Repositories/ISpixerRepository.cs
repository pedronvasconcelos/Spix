using Spix.Domain.Core;
using Spix.Domain.Entities;

namespace Spix.Domain.Repositories;

public interface ISpixerRepository : IRepository<Spixer>
{
    Task<bool> IsSpixerLikedByUserAsync(Guid spixerId, Guid userId);
    Task AddSpixerLikeAsync(SpixerLike spixerLike);

    Task<SpixerLike?> GetSpixerLikeAsync(Guid spixerId, Guid userId);
    Task DeleteSpixerLikeAsync(SpixerLike spixerLike);
}
