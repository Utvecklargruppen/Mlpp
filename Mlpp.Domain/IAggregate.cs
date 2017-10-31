namespace Mlpp.Domain
{
    public interface IAggregate<out TState, out TId> : IStateObject<TState>
    {
        TId Id { get; }
    }
}
