using System;

namespace Mlpp.ApplicationService.Product.Command
{
    public class CreateProduct : IAggregateCommand<Guid>
    {
        public CreateProduct(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
