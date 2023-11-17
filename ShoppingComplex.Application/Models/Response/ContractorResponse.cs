namespace ShoppingComplex.Application.Models.Response
{
    public class ContractorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Status { get; set; }
    }
}