using ShoppingComplex.Core.Entities;

namespace ShoppingComplex.Application.Models.Response
{
    public class MaintenanceResponse
    {
        public int Id { get; set; }
        public string MaintenanceType { get; set; } = null!;
        public string Location { get; set; } = null!;
        public Contractor ContractorNavigations { get; set; } = null!;
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public int TotalCharge { get; set; }
        public int AdvancedValue { get; set; }
        public int Status { get; set; }
    }
}