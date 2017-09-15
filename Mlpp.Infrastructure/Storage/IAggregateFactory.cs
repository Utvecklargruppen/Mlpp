namespace Mlpp.Infrastructure.Storage
{
    public interface IAggregateFactory
    {
        TAggregate Create<TAggregate, TState>(TState state) where TAggregate : class;
    }
}