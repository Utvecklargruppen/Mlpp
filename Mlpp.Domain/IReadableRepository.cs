namespace Mlpp.Domain
{
    public interface IReadableRepository<out TAggregate, in TId>
    {
        TAggregate GetById(TId id);
        TAggregate SafeGetById(TId id);
    }
}
