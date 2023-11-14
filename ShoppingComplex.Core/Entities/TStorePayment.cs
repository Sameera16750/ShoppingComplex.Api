using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class TStorePayment
    {
        public int Id { get; set; }
        public string Year { get; set; } = null!;
        public string Month { get; set; } = null!;
        public int PayedValue { get; set; }
        public int PendingValue { get; set; }
        public int Store { get; set; }
        public int Status { get; set; }

        public virtual TStore StoreNavigation { get; set; } = null!;
    }
}
