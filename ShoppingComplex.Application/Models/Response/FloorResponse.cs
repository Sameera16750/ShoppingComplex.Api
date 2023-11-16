namespace ShoppingComplex.Application.Models.Response
{
    public class FloorResponse
    {
        public int Id { get; set; }
        public string FloorNumber { get; set; } = null!;
        public int TotalSpaces { get; set; }
        public int Status { get; set; }
    }    
}
