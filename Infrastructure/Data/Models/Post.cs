using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Data.Models
{
    public class Post
    {
        [Key]
        [Comment("Unique identifier for the post.")]
        public int Id { get; set; }

        [Comment("Image of the post.")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Date when the post was created.")]
        public DateTime CreatedAt { get; set; } 

       
        [Required]
        [Comment("Identifier of the user who made the post.")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [Comment("Identifier of the thread this post belongs to.")]
        public int ThreadId { get; set; }

        [ForeignKey(nameof(ThreadId))]
        public Thread Thread { get; set; } = null!;

        [Comment("Collection of comments for the post.")]
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
