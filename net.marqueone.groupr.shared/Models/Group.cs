using System;
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
        public DateTimeOffset Created { get; set; }

        [Column]
        [Required]
        public string CreatedBy { get; set; }

        [Column]
        public DateTimeOffset? Updated { get; set; }

        [Column]
        public int UpdatedBy { get; set; }
    }
}