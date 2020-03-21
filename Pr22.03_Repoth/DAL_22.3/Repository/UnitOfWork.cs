using DAL_22._3.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_22._3
{
    public class UnitOfWork : IDisposable
    {
        private SchoolContext context = new SchoolContext();
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Department> departmantRepository;
        private GenericRepository<Course> courseRepository;

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        public GenericRepository<Department> DepartmantRepository {
            get
            {
                if (this.departmantRepository == null)
                {
                    this.departmantRepository = new GenericRepository<Department>(context);
                }
                return departmantRepository;
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {
                if (this.courseRepository == null)
                {
                    this.courseRepository = new GenericRepository<Course>(context);
                }
                return courseRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }


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
    }
}
