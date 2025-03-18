using Forum.Infrastructure.Data.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [Comment("Identifier of the user who made the Category.")]
        public string CreatorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;


        [Comment("Collection of threads in this category.")]
        public virtual ICollection<Thread> Threads { get; set; } = new List<Thread>();


    }
}