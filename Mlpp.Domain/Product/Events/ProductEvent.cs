namespace Mlpp.Domain.Product.Events
{
    public abstract class ProductEvent
    {
        protected ProductEvent(ProductAggregate product)
        {
            Product = product;
        }

        public ProductAggregate Product { get; }
    }
}
