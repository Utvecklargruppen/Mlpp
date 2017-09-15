using System;

namespace Mlpp.ApplicationService.Product.Command
{
    public class RemoveProduct : IAggregateCommand<Guid>
    {
        public RemoveProduct(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
