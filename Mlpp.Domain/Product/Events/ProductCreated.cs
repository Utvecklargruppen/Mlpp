namespace Mlpp.Domain.Product.Events
{
    public class ProductCreated
    {
        public ProductCreated(ProductAggregate product)
        {
            Product = product;
        }

        public ProductAggregate Product { get; }
    }
}
