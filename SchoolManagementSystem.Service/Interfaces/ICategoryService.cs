using SchoolManagementSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Service.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetCategories(Expression<Func<Category, bool>> where);
        Category GetCategory(int categoryId);
        IEnumerable<Category> Search(string searchText);
        void CreateCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(Category category);
        void DeleteCategory(int categoryId);
    }
}
