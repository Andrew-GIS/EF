using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_DB_FluentAPI.Model
{
    public class JobHistory
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int JobId { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<Employeey> Employeeys { get; set; }
        public Department Department { get; set; }
        public Jobs Job { get; set; }
    }
}