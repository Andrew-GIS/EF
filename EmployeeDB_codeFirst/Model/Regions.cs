﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeDB_codeFirst.Model
{
    public class Regions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegionId { get; set; }

        public string RegionName { get; set; }

        public ICollection<Countries> Countries { get; set; }
    }
}