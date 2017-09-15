using System;
using Mlpp.ApplicationService;

namespace Mlpp.ApplicationService.Product.Command
{
    public class ChangeProductName : IAggregateCommand<Guid>
    {
        public ChangeProductName(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
