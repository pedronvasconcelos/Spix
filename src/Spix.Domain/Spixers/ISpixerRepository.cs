
using Spix.Domain.Core;
using Spix.Domain.Likes;

namespace Spix.Domain.Spixers;

public interface ISpixerRepository : IRepository<Spixer>    
{
    Task<bool> IsSpixerLikedByUserAsync(Guid spixerId, Guid userId);
    Task AddSpixerLikeAsync(SpixerLike spixerLike);
}
