namespace Mlpp.Domain
{
    public interface IReadableRepository<TAggregate, TId>
    {
        TAggregate GetById(TId id);
        TAggregate SafeGetById(TId id);
    }
}
