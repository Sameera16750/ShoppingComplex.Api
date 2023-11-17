namespace ShoppingComplex.Application.Models.Request
{
    public class MaintenanceRequest
    {
        public string MaintenanceType { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Contractor { get; set; }
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public int TotalCharge { get; set; }
        public int AdvancedValue { get; set; }
        public int Status { get; set; }
    }
}