using Student_Fees.Models;
using System;
using System.Collections.Generic;

namespace Student_Fees
{
    public class StartupData
    {
        private readonly StudentFeesDbContext StudentFeesDbContext;

        public StartupData(StudentFeesDbContext studentFeesDbContext)
        {
            StudentFeesDbContext = studentFeesDbContext;
        }

        public void Create()
        {
            // Define startup students.
            List<Student> startupStudents = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Forename = "Flint",
                    Surname = "Lockwood"
                },
                new Student
                {
                    Id = 2,
                    Forename = "Sam",
                    Surname = "Sparks"
                },
                new Student
                {
                    Id = 3,
                    Forename = "Steve",
                    Surname = "Lockwood"
                },
                new Student
                {
                    Id = 4,
                    Forename = "Earl",
                    Surname = "Devereaux"
                },
                new Student
                {
                    Id = 5,
                    Forename = "Brent",
                    Surname = "McHale"
                }
            };

            // Define startup payments.
            List<Payment> startupPayments = new List<Payment>
            {
                new Payment
                {
                    Id = 1,
                    StudentId = 3,
                    Amount = 9000,
                    Date = DateTime.Parse("2017-06-03")
                },
                new Payment
                {
                    Id = 2,
                    StudentId = 2,
                    Amount = 9000,
                    Date = DateTime.Parse("2017-03-08")
                },
                new Payment
                {
                    Id = 3,
                    StudentId = 2,
                    Amount = 9000,
                    Date = DateTime.Parse("2017-05-04")
                }
            };

            // Add students and payments to the context.
            StudentFeesDbContext.Students.AddRange(startupStudents);
            StudentFeesDbContext.Payments.AddRange(startupPayments);

            // Commit the changes to the context.
            StudentFeesDbContext.SaveChanges();
        }
    }
}