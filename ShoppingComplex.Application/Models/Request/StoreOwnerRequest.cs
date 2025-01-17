﻿namespace ShoppingComplex.Application.Models.Request
{
    public class StoreOwnerRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Nic { get; set; } = null!;
        public int Status { get; set; }
    }
}

