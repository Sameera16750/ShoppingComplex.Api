using ShoppingComplex.Core.Entities;

namespace ShoppingComplex.Application.Models.Response
{
    public class SpaceResponse
    {
    
        public int Id { get; set; }
        public FloorResponse FloorNavigation { get; set; } = null!;
        public string SpaceNumber { get; set; } = null!;
        public string SpaceSize { get; set; } = null!;
        public int Status { get; set; }
    }    
}

