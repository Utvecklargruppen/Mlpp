namespace Mlpp.Domain.Product.Events
{
    public class ProductRemoved : ProductEvent
    {
        public ProductRemoved(ProductAggregate product) : base(product)
        {
        }
    }
}
