namespace Spix.Domain.Abstraction
{
    public interface IDomainEvent  
    {
        DateTime OccurredOn { get; }
    }
}
