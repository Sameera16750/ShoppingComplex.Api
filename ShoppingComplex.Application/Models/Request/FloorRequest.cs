namespace ShoppingComplex.Application.Models.Request;

public class FloorRequest
{
    public string FloorNumber { get; set; } = null!;
    public int TotalSpaces { get; set; }
    public int Status { get; set; }
}