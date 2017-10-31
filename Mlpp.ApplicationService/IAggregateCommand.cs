namespace Mlpp.ApplicationService
{
    public interface IAggregateCommand<out TId> : ICommand
    {
        TId AggregateId { get; }
    }
}
