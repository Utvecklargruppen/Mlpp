using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mlpp.Domain.Product.States
{
    [Table("Product")]
    public class ProductState
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        private ICollection<PartState> _parts;
        public ICollection<PartState> Parts
        {
            get => _parts ?? (_parts = new List<PartState>());
            set => _parts = value;
        }

    }
}
