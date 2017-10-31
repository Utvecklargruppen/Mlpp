using System;

namespace Mlpp.ApplicationService.Product.Command
{
    public class CreateProduct : ProductCommand
    {
        public CreateProduct(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
