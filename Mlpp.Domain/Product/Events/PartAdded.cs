using Mlpp.Domain.Part;

namespace Mlpp.Domain.Product.Events
{
    public class PartAdded
    {
        public PartAdded(ProductAggregate product, PartAggregate part)
        {
            Product = product;
            Part = part;
        }

        public ProductAggregate Product { get; }
        public PartAggregate Part { get; }
    }
}
