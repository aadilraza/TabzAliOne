using SchoolManagementSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Service.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        IEnumerable<Course> GetCourses(Expression<Func<Course, bool>> where);
        IEnumerable<Course> GetByCategory(int categoryId);
        IEnumerable<Course> GetSubCourses(int courseId);
        Course GetParent(int courseId);
        Course GetCourse(int courseId);
        IEnumerable<Course> Search(string searchText);
        void UpdateCourseDuration(int courseId, int newDuration);
        void ActivateCourse(int courseId);
        void DeactivateCourse(int courseId);
        void CreateCourse(Course course);
        void EditCourse(Course course);
        void DeleteCourse(Course course);
        void DeleteCourse(int courseId);
    }
}
