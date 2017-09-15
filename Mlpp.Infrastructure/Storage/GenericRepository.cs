using Microsoft.EntityFrameworkCore;
using Mlpp.Domain;

namespace Mlpp.Infrastructure.Storage
{
    public class GenericRepository<TContext, TAggregate, TState, TId> : IReadableRepository<TAggregate, TId>, IWriteableRepository<TAggregate, TId>
        where TContext : IContext
        where TState : class
        where TAggregate : class, IAggregate<TState, TId>
    {
        protected GenericRepository(TContext context, IAggregateFactory aggregateFactory)
        {
            Context = context;
            Factory = aggregateFactory;
        }

        protected IAggregateFactory Factory { get; }
        protected TContext Context { get; }

        public virtual TAggregate GetById(TId id)
        {
            var set = Context.Set<TState>();
            return CreateAggregate(set.Find(id));
        }

        public virtual TAggregate SafeGetById(TId id)
        {
            var set = Context.Set<TState>();
            var aggregate = CreateAggregate(set.Find(id));
            if (aggregate == null)
            {
                throw new NotFoundException($"No aggregate with id {id} could be found.");
            }

            return aggregate;
        }

        public virtual void Insert(TAggregate aggregate)
        {
            Context.SetEntityState(aggregate.GetInternalState(), EntityState.Added);
        }

        public virtual void Update(TAggregate aggregate)
        {
            Context.SetEntityState(aggregate.GetInternalState(), EntityState.Modified);
        }

        public virtual void Delete(TId aggregateId)
        {
            var set = Context.Set<TState>();
            var state = set.Find(aggregateId);
            if (state != null)
            {
                set.Remove(state);
            }
        }

        public virtual void Delete(TAggregate aggregate)
        {
            var set = Context.Set<TState>();
            set.Remove(aggregate.GetInternalState());
        }

        protected virtual TAggregate CreateAggregate(TState state)
        {
            return Factory.Create<TAggregate, TState>(state);
        }
    }
}

