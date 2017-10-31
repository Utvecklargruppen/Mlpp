namespace Mlpp.Domain.Product.Events
{
    public class PartRemoved
    {
        public PartRemoved(ProductAggregate product, Part part)
        {
            Product = product;
            Part = part;
        }

        public ProductAggregate Product { get; }
        public Part Part { get; }
    }
}
