using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class StoreOwner
    {
        public StoreOwner()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Nic { get; set; } = null!;
        public int Status { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
