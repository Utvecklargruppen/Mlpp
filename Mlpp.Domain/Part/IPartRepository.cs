using System;

namespace Mlpp.Domain.Part
{
    public interface IPartRepository : IReadableRepository<PartAggregate, Guid>, IWriteableRepository<PartAggregate, Guid>
    {
    }
}