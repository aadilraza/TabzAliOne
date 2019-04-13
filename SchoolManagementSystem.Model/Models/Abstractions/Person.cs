using System.Collections.Generic;

namespace SchoolManagementSystem.Model.Models.Abstractions
{
    public abstract class Person
    {
        public Person()
        {
            Payments = new List<Payment>();
            IsActive = true;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public bool IsActive { get; set; }
        public decimal TotalDue { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
