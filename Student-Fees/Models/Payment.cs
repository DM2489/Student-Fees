using System;

namespace Student_Fees.Models
{
    public class Payment
    {
        public long Id { get; set; }

        public long StudentId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}