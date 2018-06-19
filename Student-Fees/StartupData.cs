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
                    Forename = "Flint",
                    Surname = "Lockwood"
                },
                new Student
                {
                    Forename = "Sam",
                    Surname = "Sparks"
                },
                new Student
                {
                    Forename = "Steve",
                    Surname = "Lockwood"
                },
                new Student
                {
                    Forename = "Earl",
                    Surname = "Devereaux"
                },
                new Student
                {
                    Forename = "Brent",
                    Surname = "McHale"
                }
            };

            // Define startup payments.
            List<Payment> startupPayments = new List<Payment>
            {
                new Payment
                {
                    StudentId = 3,
                    Amount = 9000,
                    Date = DateTime.Parse("2017-06-03")
                },
                new Payment
                {
                    StudentId = 2,
                    Amount = 9000,
                    Date = DateTime.Parse("2017-03-08")
                },
                new Payment
                {
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