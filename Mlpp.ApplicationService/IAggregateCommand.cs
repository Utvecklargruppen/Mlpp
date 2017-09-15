namespace Mlpp.ApplicationService
{
    public interface IAggregateCommand<TId>
    {
        TId Id { get; }
    }
}
