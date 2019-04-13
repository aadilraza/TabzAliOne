using SchoolManagementSystem.Model.Enums;
using SchoolManagementSystem.Model.Models.Abstractions;
using System;

namespace SchoolManagementSystem.Model.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public bool Paid { get; set; }
    }
}
