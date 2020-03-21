using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_22._3.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public override string ToString()
        {
            return $"Department - {Name}";
        }
    }
}
