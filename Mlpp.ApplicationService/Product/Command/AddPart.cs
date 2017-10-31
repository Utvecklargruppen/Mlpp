using System;

namespace Mlpp.ApplicationService.Product.Command
{
    public class AddPart : ProductPartCommand
    {
        public AddPart(Guid productId, Guid partId) : base(productId, partId)
        {
        }
    }
}
