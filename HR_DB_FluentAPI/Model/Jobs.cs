using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_DB_FluentAPI.Model
{
    public class Jobs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        public string JobTitle { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }

        public ICollection<Employeey> Employeeys { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }
    }
}