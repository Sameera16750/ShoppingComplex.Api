using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class Floor
    {
        public Floor()
        {
            Spaces = new HashSet<Space>();
        }

        public int Id { get; set; }
        public string FloorNumber { get; set; } = null!;
        public int TotalSpaces { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Space> Spaces { get; set; }
    }
}
