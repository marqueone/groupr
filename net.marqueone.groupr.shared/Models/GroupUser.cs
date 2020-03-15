using System.ComponentModel.DataAnnotations;

namespace net.marqueone.groupr.shared.Models
{
    public class GroupUser
    {
        [Required]
        public int GroupId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}