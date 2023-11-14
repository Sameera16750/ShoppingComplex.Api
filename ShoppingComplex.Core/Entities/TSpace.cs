using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class TSpace
    {
        public TSpace()
        {
            TStores = new HashSet<TStore>();
        }

        public int Id { get; set; }
        public int Floor { get; set; }
        public string SpaceNumber { get; set; } = null!;
        public string SpaceSize { get; set; } = null!;
        public int Status { get; set; }

        public virtual TFloor FloorNavigation { get; set; } = null!;
        public virtual ICollection<TStore> TStores { get; set; }
    }
}
