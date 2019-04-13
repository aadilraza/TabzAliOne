using SchoolManagementSystem.Model.Models;
using System.Collections.Generic;

namespace SchoolManagementSystem.Service.Interfaces
{
    public interface ICityService
    {
        IEnumerable<City> GetCities();
        City GetCity(int id);
    }
}
