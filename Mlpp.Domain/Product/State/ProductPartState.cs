using System;
using Mlpp.Domain.Part.State;

namespace Mlpp.Domain.Product.State
{
    public class ProductPartState
    {
        public Guid ProductId { get; set; }
        public ProductState Product { get; set; }

        public Guid PartId { get; set; }
        public PartState Part { get; set; }
    }
}