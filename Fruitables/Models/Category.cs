using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Fruitables.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
