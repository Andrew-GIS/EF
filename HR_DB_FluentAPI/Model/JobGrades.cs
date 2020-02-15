﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_DB_FluentAPI.Model
{
    public class JobGrades
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string GradeLevel { get; set; }

        public decimal LowestSalary { get; set; }

        public int HighestSalary { get; set; }
    }
}