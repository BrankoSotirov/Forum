using Forum.Infrastructure.Data.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Infrastructure.Data.Models
{
    public class CommentReport
    {
        [Key]
        [Comment("Unique identifier for the report.")]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.CommentReportMaxLength)]
        [Comment("Reason or description for reporting the comment.")]
        public string Reason { get; set; } = string.Empty;
      
        [Required]
        [Comment("Identifier of the user who reported the comment.")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        
        [Required]
        [Comment("Identifier of the reported comment.")]
        public int CommentId { get; set; }

        [ForeignKey(nameof(CommentId))]
        public Comment Comment { get; set; } = null!;
    }
}
