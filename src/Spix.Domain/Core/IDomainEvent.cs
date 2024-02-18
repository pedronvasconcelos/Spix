namespace Spix.Domain.Core
{
    public interface IDomainEvent  
    {
        DateTime OccurredOn { get; }
    }
}
