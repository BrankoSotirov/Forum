using Forum.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Comment
{
    [Key]
    [Comment("Unique identifier for the comment.")]
    public int Id { get; set; }

    [Required]
    [Comment("Content of the comment.")]
    public string Content { get; set; } = string.Empty;


    [Required]
    [Comment("Identifier of the user who made the comment.")]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey(nameof(UserId))]
    public IdentityUser User { get; set; } = null!;

    [Required]
    [Comment("Identifier of the post this comment belongs to.")]
    public int PostId { get; set; }

    [ForeignKey(nameof(PostId))]
    public virtual Post Post { get; set; } = null!;
}
