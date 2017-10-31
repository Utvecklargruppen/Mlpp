using System;

namespace Mlpp.ApplicationService.Part.Command
{
    public abstract class PartCommand : IAggregateCommand<Guid>
    {
        protected PartCommand(Guid id)
        {
            AggregateId = id;
        }

        public Guid AggregateId { get; }
    }
}
