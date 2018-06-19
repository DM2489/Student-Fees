using System.Collections.Generic;

namespace Student_Fees.Models
{
    public class Student
    {
        public long Id { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public List<Payment> Payments { get; set; }
    }
}