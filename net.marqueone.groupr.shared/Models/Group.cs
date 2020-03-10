using System;

namespace net.marqueone.groupr.shared.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public int UpdatedBy { get; set; }
    }
}