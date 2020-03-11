using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net.marqueone.groupr.shared.Models
{
    [Table("groups")]
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Column]
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Column]
        [Required]
        [MaxLength(256)]
        public string NormalizedName { get; set; }

        [Column]
        [MaxLength(1024)]
        public string Description { get; set; }

        [Column]
        [Required]
        public DateTimeOffset Created { get; set; }

        [Column]
        [Required]
        [MaxLength(400)]
        public string CreatedBy { get; set; }

        [Column]
        public DateTimeOffset? Updated { get; set; }

        [Column]
        [MaxLength(400)]
        public string UpdatedBy { get; set; }

        public virtual List<GroupMember> Members { get; set; }
    }
}