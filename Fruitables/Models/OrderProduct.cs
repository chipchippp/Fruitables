using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fruitables.Models
{
    public class OrderProduct
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public short Qty { get; set; } = 0;
        public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
        {
            public void Configure(EntityTypeBuilder<OrderProduct> builder)
            {
                builder.HasKey(op => new { op.OrderId, op.ProductId });
            }
        }
    }
}
