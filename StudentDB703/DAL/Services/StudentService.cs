using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace DAL.Services
{
    public class StudentService: IStudentService
    {
        private StudentContext context;
        public StudentService()
        {
            context = new StudentContext();
        }

        public IEnumerable<Student> GetStudents()
        {
            return this.context.Students.Include(s => s.Books).Include(s => s.Address);
            //.Include(s => s.Address)
            //this.context.Students.Include(s => s.StudentAddress);


            //return this.context.Students.Include(s => s.Books).Include(s => s.StudentAddress);
        }

        public void SaveStudents()
        {
            context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            context.Students.Remove(student);
        }
    }
}