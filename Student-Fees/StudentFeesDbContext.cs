using Microsoft.EntityFrameworkCore;
using Student_Fees.Models;

namespace Student_Fees
{
    public class StudentFeesDbContext : DbContext
    {
        public StudentFeesDbContext(DbContextOptions<StudentFeesDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Payment> Payments { get; set; }
    }
}