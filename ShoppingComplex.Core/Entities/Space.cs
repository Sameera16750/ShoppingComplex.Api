using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class Space
    {
        public Space()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public int Floor { get; set; }
        public string SpaceNumber { get; set; } = null!;
        public string SpaceSize { get; set; } = null!;
        public int Status { get; set; }

        public virtual Floor FloorNavigation { get; set; } = null!;
        public virtual ICollection<Store> Stores { get; set; }
    }
}
