using Mlpp.Domain.Product.State;
using System;
using System.Collections.Generic;

namespace Mlpp.Domain.Part.State
{
    public class PartState
    {
        private ICollection<ProductPartState> _products;

        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Removed { get; set; }

        public ICollection<ProductPartState> Products
        {
            get => _products ?? (_products = new List<ProductPartState>());
            set => _products = value;
        }
    }
}