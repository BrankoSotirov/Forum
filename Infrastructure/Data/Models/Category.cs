using Forum.Infrastructure.Data.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Forum.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        [Comment("Unique identifier for the category.")]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.CategoryNameMaxLength, MinimumLength = DataConstants.CategoryNameMinLength)]
        [Comment("The name of the category.")]
        public string Name { get; set; } = string.Empty;

       
        [Comment("Collection of threads in this category.")]
        public virtual ICollection<Thread> Threads { get; set; } = new List<Thread>();


    }
}