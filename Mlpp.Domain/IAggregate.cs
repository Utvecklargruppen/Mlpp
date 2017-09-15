namespace Mlpp.Domain
{
    public interface IAggregate<TState, TId> : IStateObject<TState>
    {
        TId Id { get; }
    }
}
