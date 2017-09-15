using System;

namespace Mlpp.Infrastructure.Storage
{
    public interface IUnitOfWork<out TContext> : IDisposable
    {
        TContext Context { get; }
        int Save();
    }
}
