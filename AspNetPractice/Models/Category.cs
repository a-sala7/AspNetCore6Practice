using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AspNetPractice.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [SetsRequiredMembers]
        public Category(string name)
        {
            Name = name;
        }

        public virtual ICollection<Product> Products { get; set; }
    }
}
