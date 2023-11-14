using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class Store
    {
        public Store()
        {
            StorePayments = new HashSet<StorePayment>();
        }

        public int Id { get; set; }
        public string StoreName { get; set; } = null!;
        public int StoreOwner { get; set; }
        public int StoreCategory { get; set; }
        public int Space { get; set; }
        public int MonthlyCharge { get; set; }
        public int KeyMoney { get; set; }
        public string RentalDate { get; set; } = null!;
        public string RentalEndDate { get; set; } = null!;
        public int Status { get; set; }

        public virtual Space SpaceNavigation { get; set; } = null!;
        public virtual StoreCatogory StoreCategoryNavigation { get; set; } = null!;
        public virtual StoreOwner StoreOwnerNavigation { get; set; } = null!;
        public virtual ICollection<StorePayment> StorePayments { get; set; }
    }
}
