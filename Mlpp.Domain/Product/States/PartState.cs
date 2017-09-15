using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mlpp.Domain.Product.States
{
    [Table("Part")]
    public class PartState
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
