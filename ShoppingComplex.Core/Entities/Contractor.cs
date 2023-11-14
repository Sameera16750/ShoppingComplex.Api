using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class Contractor
    {
        public Contractor()
        {
            Maintenances = new HashSet<Maintenance>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Status { get; set; }

        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }
}
