using System;

namespace Mlpp.ApplicationService.Product.Command
{
    public class RemovePart : ProductPartCommand
    {
        public RemovePart(Guid productId, Guid partId) : base(productId, partId)
        {
        }
    }
}
