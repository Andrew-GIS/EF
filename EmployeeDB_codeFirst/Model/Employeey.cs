using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeDB_codeFirst.Model
{
    public class Employeey
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public decimal CommisionPercent { get; set; }

        public int ManagerId { get; set; }

        public int DeparpmentId { get; set; }

        //Department connection
        //public int? DeparmentId { get; set; }
        public Departments Departments { get; set; }

        //Job History connetion
        //public int? JobHistory.EmployeeId { get; set; }
        public JobHistory JobHistory { get; set; }

        //Jobs connetion
        public Jobs Jobs { get; set; }
    }
}