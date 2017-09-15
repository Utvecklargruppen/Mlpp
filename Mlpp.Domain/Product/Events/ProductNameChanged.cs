namespace Mlpp.Domain.Product.Events
{
    public class ProductNameChanged
    {
        public ProductNameChanged(ProductAggregate product)
        {
            Product = product;
        }

        public ProductAggregate Product { get; }
    }
}
