using SchoolManagementSystem.Data.Configuration;
using SchoolManagementSystem.Model.Models;
using SchoolManagementSystem.Model.Models.Abstractions;
using System.Data.Entity;

namespace SchoolManagementSystem.Data
{
    public class SchoolEntities : DbContext
    {
        public SchoolEntities() : base("SchoolEntities")
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<CourseOffering> CourseOfferings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<CourseOfferingSession> CourseOfferingSessions { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new InstructorConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new CourseOfferingSessionConfiguration());
            modelBuilder.Configurations.Add(new StudentAttendanceConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CourseOfferingConfiguration());
        }
    }
}
