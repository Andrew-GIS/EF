using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DAL_22._3.Model
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public virtual ObservableCollection<Student> Students { get; set; }
        public virtual Department Department { get; set; }

        public override string ToString()
        {
            return $"Cource - {Name}";
        }
    }
}
