using Microsoft.EntityFrameworkCore;
using Mlpp.Domain;
using System;

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

        protected TContext Context { get; }
        protected IAggregateFactory Factory { get; }

        public virtual void Delete(TAggregate aggregate)
        {
            if (aggregate == null)
            {
                throw new ArgumentNullException(nameof(aggregate));
            }

            var set = Context.Set<TState>();
            set.Remove(aggregate.GetInternalState());
        }

        public virtual TAggregate GetById(TId id)
        {
            var set = Context.Set<TState>();
            return CreateAggregate(set.Find(id));
        }

        public virtual void Insert(TAggregate aggregate)
        {
            if (aggregate == null)
            {
                throw new ArgumentNullException(nameof(aggregate));
            }

            Context.SetEntityState(aggregate.GetInternalState(), EntityState.Added);
        }

        public virtual TAggregate SafeGetById(TId id)
        {
            var set = Context.Set<TState>();
            var aggregate = CreateAggregate(set.Find(id));
            if (aggregate == null)
            {
                throw new AggregateNotFoundException($"No aggregate with id {id} could be found.");
            }
            return aggregate;
        }

        public virtual void Update(TAggregate aggregate)
        {
            if (aggregate == null)
            {
                throw new ArgumentNullException(nameof(aggregate));
            }

            Context.SetEntityState(aggregate.GetInternalState(), EntityState.Modified);
        }

        protected virtual TAggregate CreateAggregate(TState state)
        {
            return Factory.Create<TAggregate, TState>(state);
        }
    }
}