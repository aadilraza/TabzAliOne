using SchoolManagementSystem.Data.Infrastructure.Interfaces;
using SchoolManagementSystem.Data.Repository.Interfaces;
using SchoolManagementSystem.Model.Models;
using SchoolManagementSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Service.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IInstructorRepository instructorRepository)
        {
            _courseRepository = courseRepository;
            _instructorRepository = instructorRepository;
            _unitOfWork = unitOfWork;
        }

        public void ActivateCourse(int courseId)
        {
            var course = _courseRepository.GetById(courseId);
            if (course != null)
            {
                course.IsActive = true;
                foreach (var subCourse in course.SubCourses)
                {
                    subCourse.IsActive = true;
                }
                _unitOfWork.Commit();
            }
        }

        public void AssignSubCourse(Course superCourse, Course subCourse)
        {
            superCourse.SubCourses.Add(subCourse);
            SaveCourse();
        }

        public void CreateCourse(Course course)
        {
            _courseRepository.Add(course);
            SaveCourse();
        }

        public void DeactivateCourse(int courseId)
        {
            var course = _courseRepository.GetById(courseId);
            if (course != null)
            {
                course.IsActive = false;
                foreach (var subCourse in course.SubCourses)
                {
                    subCourse.IsActive = false;
                }
                _unitOfWork.Commit();
            }
        }

        public void DeleteCourse(Course course)
        {
            _courseRepository.Delete(course);
            SaveCourse();
        }

        public void DeleteCourse(int courseId)
        {
            _courseRepository.Delete(courseId);
            SaveCourse();
        }

        public void EditCourse(Course course)
        {
            _courseRepository.Update(course);
            SaveCourse();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAll().OrderBy(c=> c.Title);
        }

        public IEnumerable<Course> GetByCategory(int categoryId)
        {
            return _courseRepository.GetMany(c => c.CategoryId == categoryId).OrderBy(c => c.Title);
        }

        public Course GetCourse(int courseId)
        {
            return _courseRepository.GetById(courseId);
        }

        public IEnumerable<Course> GetCourses(Expression<Func<Course, bool>> where)
        {
            return _courseRepository.GetMany(where).OrderBy(c => c.Title);
        }

        public Course GetParent(int courseId)
        {
            var course = _courseRepository.GetById(courseId);
            return course.Parent;
        }

        public IEnumerable<Course> GetSubCourses(int courseId)
        {
            var course = _courseRepository.GetById(courseId);
            return course.SubCourses.OrderBy(c => c.Title);
        }

        public IEnumerable<Course> Search(string searchText)
        {
            return _courseRepository.GetMany(c => c.Title.Contains(searchText) 
                || c.Description.Contains(searchText))
                .OrderBy(c => c.Title); ;
        }

        public void UpdateCourseDuration(int courseId, int newDuration)
        {
            var course = _courseRepository.GetById(courseId);
            course.Duration = newDuration;
            SaveCourse();
        }

        private void SaveCourse()
        {
            _unitOfWork.Commit();
        }
    }
}
