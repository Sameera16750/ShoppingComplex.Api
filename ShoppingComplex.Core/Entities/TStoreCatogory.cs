using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class TStoreCatogory
    {
        public TStoreCatogory()
        {
            TStores = new HashSet<TStore>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public int Status { get; set; }

        public virtual ICollection<TStore> TStores { get; set; }
    }
}
