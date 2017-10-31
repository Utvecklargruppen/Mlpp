using System;

namespace Mlpp.ApplicationService.Product.Command
{
    public abstract class ProductPartCommand : ProductCommand
    {
        protected ProductPartCommand(Guid productId, Guid partId) : base(productId)
        {
            PartId = partId;
        }

        public Guid PartId { get; }
    }
}