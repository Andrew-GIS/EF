using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DAL.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public override string ToString()
        {
            return $"{this.Country}: {this.City}, {this.StreetAddress} - {this.PostalCode}".ToString();
        }
    }
}
