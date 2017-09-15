using System;

namespace Mlpp.Infrastructure.Storage
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : IDisposable, IContext
    {
        public UnitOfWork(TContext context)
        {
            Context = context;
        }

        public TContext Context { get; }

        public void Dispose()
        {
            Context.Dispose();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}
