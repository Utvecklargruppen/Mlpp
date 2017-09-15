using Microsoft.EntityFrameworkCore;
using System;

namespace Mlpp.Infrastructure.Storage
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
        DbSet<T> Set<T>() where T : class;
        void SetEntityState(object entity, EntityState state);
        EntityState GetEntityState(object entity);
    }
}
