using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class TFloor
    {
        public TFloor()
        {
            TSpaces = new HashSet<TSpace>();
        }

        public int Id { get; set; }
        public string FloorNumber { get; set; } = null!;
        public int TotalSpaces { get; set; }
        public int Status { get; set; }

        public virtual ICollection<TSpace> TSpaces { get; set; }
    }
}
