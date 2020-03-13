using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_22._3.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public virtual Course Course { get; set; }
    }
}
