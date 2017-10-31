namespace Mlpp.Infrastructure.Storage
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;

        protected UnitOfWork(IContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
