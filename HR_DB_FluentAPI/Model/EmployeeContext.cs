using Microsoft.EntityFrameworkCore;


namespace HR_DB_FluentAPI.Model
{
    public class EmployeeContext: DbContext
    {
        //public EmployeeContext() : base("EmployeeyDb")
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"DataBase=EmployeeDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>()
                .HasMany<Employeey>(department => department.Employeeys)
                .WithOne(employee => employee.Department)
                .HasForeignKey(employee => employee.DeparpmentId);

            modelBuilder.Entity<Jobs>()
                .HasMany<Employeey>(job => job.Employeeys)
                .WithOne(employee => employee.Jobs);
                //.HasForeignKey(employee => employee.JobId);

            modelBuilder.Entity<JobHistory>()
           .HasKey(sc => new { sc.EmployeeId, sc.StartDate });

            modelBuilder.Entity<JobHistory>()
                .HasMany<Employeey>(jobhist => jobhist.Employeeys)
                .WithOne(employee => employee.JobHistory)
                ;

            modelBuilder.Entity<JobHistory>()
            .HasOne<Department>(department => department.Department)
            .WithMany(jobHistory => jobHistory.JobHistories);
            

            modelBuilder.Entity<Jobs>()
                .HasMany<JobHistory>(job => job.JobHistories)
                .WithOne(jobHistory => jobHistory.Job)
                .HasForeignKey(jobHistory => jobHistory.JobId);

            modelBuilder.Entity<Locations>()
                .HasMany<Department>(location => location.Departments)
                .WithOne(department => department.Locations)
                .HasForeignKey(department => department.LocationId);

            modelBuilder.Entity<Countries>()
                .HasMany<Locations>(counrty => counrty.Locations)
                .WithOne(location => location.Countries)
                .HasForeignKey(location => location.CountryId);

            modelBuilder.Entity<Regions>()
                .HasMany<Countries>(region => region.Countries)
                .WithOne(country => country.Regions)
                .HasForeignKey(country => country.RegionId);
        }

        public DbSet<Employeey> Employees { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Regions> Regions { get; set; }
        //public DbSet<JobGrades> JobGrades { get; set; }
    }
}
