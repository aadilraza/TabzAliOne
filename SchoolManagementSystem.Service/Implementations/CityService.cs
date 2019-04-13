using SchoolManagementSystem.Data.Repository.Interfaces;
using SchoolManagementSystem.Model.Models;
using SchoolManagementSystem.Service.Interfaces;
using System.Collections.Generic;

namespace SchoolManagementSystem.Service.Implementations
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public IEnumerable<City> GetCities()
        {
            return _cityRepository.GetAll();
        }

        public City GetCity(int id)
        {
            return _cityRepository.GetById(id);
        }
    }
}
