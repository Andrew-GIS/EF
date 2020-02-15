using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeDB_codeFirst.Model
{
    public class Countries
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public int RegionId { get; set; }

        public ICollection<Locations> Locations { get; set; }

        public Regions Regions { get; set; }
    }
}