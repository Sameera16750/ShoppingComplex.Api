namespace ShoppingComplex.Application.Models.Request
{
    public class StoreRequest
    {
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

    }    
}

