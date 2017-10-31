using Mlpp.Domain.Part;
using Mlpp.Domain.Part.State;
using System;

namespace Mlpp.Infrastructure.Storage.Mlpp.Repository
{
    public class PartRepository :
        GenericRepository<MlppContext, PartAggregate, PartState, Guid>,
        IPartRepository
    {
        public PartRepository(MlppContext context, IAggregateFactory aggregateFactory)
            : base(context, aggregateFactory)
        {
        }
    }
}