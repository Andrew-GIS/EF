using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeDB_codeFirst.Model
{
    public class Locations
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        public string StreetAddress { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public int CountryId { get; set; }

        public ICollection<Departments> Departments { get; set; }

        public Countries Countries { get; set; }
    }
}