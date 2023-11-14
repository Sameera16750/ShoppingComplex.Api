using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class StoreCatogory
    {
        public StoreCatogory()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public int Status { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
