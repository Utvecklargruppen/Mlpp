using System;

namespace Mlpp.ApplicationService.Product.Command
{
    public class RemoveProduct : ProductCommand
    {
        public RemoveProduct(Guid id) : base(id)
        {
        }
    }
}
