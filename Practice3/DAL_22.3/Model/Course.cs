using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_22._3.Model
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public virtual Student Student { get; set; }
        public virtual Department Department { get; set; }
    }
}
