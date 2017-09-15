namespace Mlpp.Domain.Product.Events
{
    public class ProductCreated : ProductEvent
    {
        public ProductCreated(ProductAggregate product) : base(product)
        {
        }
    }
}
