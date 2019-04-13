using SchoolManagementSystem.Model.Models.Abstractions;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class PersonConfiguration: EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            Property(p => p.FirstName).IsRequired();
            Property(p => p.LastName).IsRequired();
            Property(p => p.Phone).IsRequired();
            Property(p => p.AddressLine1).IsRequired();
            Property(p => p.CityId).IsRequired();
        }
    }
}
