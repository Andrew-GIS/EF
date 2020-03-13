using DAL_22._3.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DAL_22._3
{
    public class StudentRepository<TEntity> : IDisposable, IStudentRepository<TEntity> 
    {
        private SchoolContext context;

        //private ObservableCollection<Student> students;

       //private DbSet<TEntity> dbSet;

        public StudentRepository(SchoolContext context)
        {
            this.context = context;
            //this.dbSet = this.context.Set<TEntity>();
        }

        public void DeleteStudent(int studentID)
        {
            Student student = context.Students.Find(studentID);
            context.Students.Remove(student);
            //TEntity deletedEntity = dbSet.Find(studentID);
            //Delete(deletedEntity);
        }

        //public void Delete(TEntity entity)
        //{
        //    dbSet.Remove(entity);
        //}

        private bool dispose = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.dispose)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Student GetStudentByID(int studentID)
        {
            return context.Students.Find(studentID);
        }

        public IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList();
        }

        public void InsertStudent(Student student)
        {
            context.Students.Add(student);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }
    }
}
