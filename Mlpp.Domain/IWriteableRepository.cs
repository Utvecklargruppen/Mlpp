namespace Mlpp.Domain
{
    public interface IWriteableRepository<in TAggregate, TId>
    {
        void Insert(TAggregate aggregate);
        void Update(TAggregate aggregate);
        void Delete(TAggregate aggregate);
    }
}
