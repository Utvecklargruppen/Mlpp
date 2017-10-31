using System;

namespace Mlpp.ApplicationService.Product.Command
{
    public abstract class ProductCommand : IAggregateCommand<Guid>
    {
        protected ProductCommand(Guid id)
        {
            AggregateId = id;
        }

        public Guid AggregateId { get; }
    }
}