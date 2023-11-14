using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class TContractor
    {
        public TContractor()
        {
            TMaintenances = new HashSet<TMaintenance>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Status { get; set; }

        public virtual ICollection<TMaintenance> TMaintenances { get; set; }
    }
}
