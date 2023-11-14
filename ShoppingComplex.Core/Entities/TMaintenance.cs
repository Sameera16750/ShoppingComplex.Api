using System;
using System.Collections.Generic;

namespace ShoppingComplex.Core.Entities
{
    public partial class TMaintenance
    {
        public int Id { get; set; }
        public string MaintenanceType { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Contractor { get; set; }
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public int TotalCharge { get; set; }
        public int AdvancedValue { get; set; }
        public int Status { get; set; }

        public virtual TContractor ContractorNavigation { get; set; } = null!;
    }
}
