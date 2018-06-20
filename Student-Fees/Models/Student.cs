using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Student_Fees.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public List<Payment> Payments { get; set; } = new List<Payment>();

        [NotMapped]
        public decimal TotalPaymentAmount
        {
            get
            {
                // Return the som of any payments for the student.
                if (Payments.Count > 0)
                {
                    return Payments.Sum(payment => payment.Amount);
                }
                else
                {
                    return 0.0m;
                }
            }
        }
    }
}