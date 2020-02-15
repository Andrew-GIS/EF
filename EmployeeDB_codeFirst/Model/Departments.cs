using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeDB_codeFirst.Model
{
    public class Departments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeparmentId { get; set; }

        public string DeparmentName { get; set; }

        public int ManagerId { get; set; }

        public int LocationId { get; set; }

        public ICollection<Employeey> Employeeys { get; set; }

        public Locations Locations { get; set; }
    }
}