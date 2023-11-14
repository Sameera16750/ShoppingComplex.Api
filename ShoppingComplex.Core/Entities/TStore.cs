using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class TStore
    {
        public TStore()
        {
            TStorePayments = new HashSet<TStorePayment>();
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

        public virtual TSpace SpaceNavigation { get; set; } = null!;
        public virtual TStoreCatogory StoreCategoryNavigation { get; set; } = null!;
        public virtual TStoreOwner StoreOwnerNavigation { get; set; } = null!;
        public virtual ICollection<TStorePayment> TStorePayments { get; set; }
    }
}
