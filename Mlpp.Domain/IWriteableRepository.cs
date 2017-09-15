namespace Mlpp.Domain
{
    public interface IWriteableRepository<TAggregate, TId>
    {
        void Insert(TAggregate aggregate);
        void Update(TAggregate aggregate);
    }
}
