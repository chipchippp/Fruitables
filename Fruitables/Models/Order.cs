using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Fruitables.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal GrandTotal { get; set; }
        public short Status { get; set; } = 0;
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string ShippingMethod { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UserId { get; set; } // Foreign Key
        public IdentityUser User { get; set; }
    }
}
