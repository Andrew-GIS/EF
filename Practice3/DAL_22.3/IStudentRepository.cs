using DAL_22._3.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_22._3
{
    public interface IStudentRepository <TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int studentID);
        void InsertStudent(Student student);
        void DeleteStudent(int studentID);
        void UpdateStudent(Student student);
        void Save();
    }
}
