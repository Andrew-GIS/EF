using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace EmployeeDB_codeFirst.Model
{
    public class EmployeeContext: DbContext
    {
        //public EmployeeContext() : base("EmployeeyDb")
        //{
            
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"database = EmployeeDB; Trusted_Connection=true");
        }

        public DbSet<Employeey> Employees { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<JobGrades> JobGrades { get; set; }
    }
}