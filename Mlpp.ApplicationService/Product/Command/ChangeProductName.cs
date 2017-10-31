using System;

namespace Mlpp.ApplicationService.Product.Command
{
    public class ChangeProductName : ProductCommand
    {
        public ChangeProductName(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
