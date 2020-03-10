using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net.marqueone.groupr.shared.Models
{
    [Table("group-members")]
    public class GroupMember
    {
        [Key]
        public int Id { get; set; }

        [Column]
        [Required]
        public int GroupId { get; set; }

        [Column]
        [Required]
        [MaxLength(400)]
        public string UserId { get; set; }

        [Column]
        public bool IsAdmin { get; set; } = false;
    }
}