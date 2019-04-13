using SchoolManagementSystem.Data.Infrastructure.Interfaces;
using SchoolManagementSystem.Data.Repository.Interfaces;
using SchoolManagementSystem.Model.Models;
using SchoolManagementSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }
        public void CreateCategory(Category category)
        {
            _categoryRepository.Add(category);
            SaveCategory();
        }

        public void DeleteCategory(Category category)
        {
            _categoryRepository.Delete(category);
            SaveCategory();
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.Delete(categoryId);
            SaveCategory();
        }

        public void EditCategory(Category category)
        {
            _categoryRepository.Update(category);
            SaveCategory();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public IEnumerable<Category> GetCategories(Expression<Func<Category, bool>> where)
        {
            return _categoryRepository.GetMany(where);
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryRepository.GetById(categoryId);
        }
        
        public IEnumerable<Category> Search(string searchText)
        {
            return _categoryRepository.GetMany(c => c.Name.Contains(searchText) || c.Desription.Contains(searchText));
        }
        private void SaveCategory()
        {
            _unitOfWork.Commit();
        }
    }
}
