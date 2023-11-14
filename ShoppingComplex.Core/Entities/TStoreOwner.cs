using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class TStoreOwner
    {
        public TStoreOwner()
        {
            TStores = new HashSet<TStore>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Nic { get; set; } = null!;
        public int Status { get; set; }

        public virtual ICollection<TStore> TStores { get; set; }
    }
}
