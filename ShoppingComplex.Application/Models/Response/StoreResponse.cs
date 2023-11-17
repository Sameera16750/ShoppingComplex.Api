namespace ShoppingComplex.Application.Models.Response
{
    public class StoreResponse
    {
        public int Id { get; set; }
        public string StoreName { get; set; } = null!;
        public StoreOwnerResponse StoreOwnerNavigation { get; set; } = null!;
        public StoreCategoryResponse StoreCategoryNavigation { get; set; } = null!;
        public SpaceResponse SpaceNavigation { get; set; } = null!;
        public int MonthlyCharge { get; set; }
        public int KeyMoney { get; set; }
        public string RentalDate { get; set; } = null!;
        public string RentalEndDate { get; set; } = null!;
        public int Status { get; set; }
    }
}