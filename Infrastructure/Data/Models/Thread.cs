using Forum.Infrastructure.Data.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Forum.Infrastructure.Data.Models
{

    public class Thread
    {
        [Key]
        [Comment("Unique identifier for the thread.")]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.ThreadNameMaxLength,MinimumLength = DataConstants.ThreadNameMinLength)]
        [Comment("The Name of the thread.")]
        public string ThreadName { get; set; } = string.Empty;


        [Required]
        [Comment("Date when the thread was created")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Comment("Identifier of the user who created the thread.")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;


        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    }
}
