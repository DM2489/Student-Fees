using Microsoft.EntityFrameworkCore;
using Student_Fees.Models;

namespace Student_Fees
{
    public class StudentFeesDbContext : DbContext
    {
        public StudentFeesDbContext(DbContextOptions<StudentFeesDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// A DbSet to represent students.
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// A DbSet to represent payments.
        /// </summary>
        public DbSet<Payment> Payments { get; set; }
    }
}