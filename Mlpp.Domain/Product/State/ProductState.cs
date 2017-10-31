using System;
using System.Collections.Generic;

namespace Mlpp.Domain.Product.State
{
    public class ProductState
    {
        private ICollection<ProductPartState> _parts;

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductPartState> Parts
        {
            get => _parts ?? (_parts = new List<ProductPartState>());
            set => _parts = value;
        }

        public bool Removed { get; set; }
    }
}