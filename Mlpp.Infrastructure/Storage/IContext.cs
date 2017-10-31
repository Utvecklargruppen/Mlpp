using Microsoft.EntityFrameworkCore;

namespace Mlpp.Infrastructure.Storage
{
    public interface IContext
    {
        int SaveChanges();
        DbSet<T> Set<T>() where T : class;
        void SetEntityState(object entity, EntityState state);
        EntityState GetEntityState(object entity);
    }
}
