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
                    Id = 2,
                    Forename = "Sam",
                    Surname = "Sparks"
                }
            };

            // Define startup payments.
            List<Payment> startupPayments = new List<Payment>
            {
                new Payment
                {
                    Id = 2,
                    StudentId = 2,
                    Amount = 9000,
                    Date = DateTime.Parse("2017-03-08")
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