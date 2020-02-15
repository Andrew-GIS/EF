using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_DB_FluentAPI.Model
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeparmentId { get; set; }

        public string DeparmentName { get; set; }

        public int ManagerId { get; set; }

        public int LocationId { get; set; }

        public ICollection<JobHistory>  JobHistories { get; set; }

        public ICollection<Employeey> Employeeys { get; set; }

        public Locations Locations { get; set; }
    }
}