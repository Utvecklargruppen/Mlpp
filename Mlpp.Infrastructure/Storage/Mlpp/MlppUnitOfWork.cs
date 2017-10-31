namespace Mlpp.Infrastructure.Storage.Mlpp
{
    public class MlppUnitOfWork : UnitOfWork, IMlppUnitOfWork
    {
        public MlppUnitOfWork(MlppContext context) : base(context)
        {
        }
    }
}
