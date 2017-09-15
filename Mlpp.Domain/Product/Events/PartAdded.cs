namespace Mlpp.Domain.Product.Events
{
    public class PartAdded
    {
        public PartAdded(ProductAggregate product, Part part)
        {
            Product = product;
            Part = part;
        }

        public ProductAggregate Product { get; }
        public Part Part { get; }
    }
}
