using Microsoft.EntityFrameworkCore;

namespace UDEMY.CQRS.Data
{
    public class StudentContext : DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> Options) : base(Options)
        {
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[] {
            new Student() { Name="Buse Nur",Age=21,SurName="Demirbaş",Id=1},
            new Student() { Name="Ayla",Age=25,SurName="Yıldız",Id=2}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
