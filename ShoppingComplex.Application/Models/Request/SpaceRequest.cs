namespace ShoppingComplex.Application.Models.Request
{
    public class SpaceRequest
    {
        public int Floor { get; set; }
        public string SpaceNumber { get; set; } = null!;
        public string SpaceSize { get; set; } = null!;
        public int Status { get; set; }
    }
}