namespace Mlpp.Domain.Product.Events
{
    public class ProductNameChanged : ProductEvent
    {
        public ProductNameChanged(ProductAggregate product) : base(product)
        {
        }
    }
}
