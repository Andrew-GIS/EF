﻿using DAL.Model;
using System.Collections.Generic;

namespace DAL.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        void SaveStudents();
        void DeleteStudent(Student student);
    }
}