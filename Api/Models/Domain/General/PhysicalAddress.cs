using System;
namespace Api.Models.Domain.General
{
    public struct PhysicalAddress
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public string PostalCode { get; set; }
    }
}
