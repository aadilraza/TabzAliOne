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
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly ICourseOfferingRepository _courseOfferingRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InstructorService(IInstructorRepository instructorRepository, ICourseRepository courseRepository, ICourseOfferingRepository courseOfferingRepository, IUnitOfWork unitOfWork)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
            _courseOfferingRepository = courseOfferingRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateInstructor(Instructor instructor)
        {
            _instructorRepository.Add(instructor);
            SaveInstructor();
        }

        public void DeleteInstructor(int instructorId)
        {
            _instructorRepository.Delete(instructorId);
            SaveInstructor();
        }

        public void DeleteInstructor(Instructor instructor)
        {
            _instructorRepository.Delete(instructor);
            SaveInstructor();
        }

        public void EditInstructor(Instructor instructor)
        {
            _instructorRepository.Update(instructor);
            SaveInstructor();
        }
        /// <summary>
        /// Returns all the insructors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Instructor> GetAllInstructors()
        {
            return _instructorRepository.GetAll();
        }

        public IEnumerable<Instructor> GetByCourse(int courseId)
        {
            var course = _courseRepository.GetById(courseId);
            var instructors = _instructorRepository.GetMany(i => i.Courses.Contains(course));
            return instructors;
        }

        public IEnumerable<Instructor> GetByCourseOffering(int courseOfferingId)
        {
            var courseOffering = _courseOfferingRepository.GetById(courseOfferingId);
            return _instructorRepository.GetMany(i => i.CourseOfferings.Any(c => c.Id == courseOfferingId));
        }
        /// <summary>
        /// Returns inactive instructors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Instructor> GetInactiveInstructors()
        {
            return _instructorRepository.GetMany(i => i.IsActive);
        }

        public Instructor GetInstructor(int instructorId)
        {
            return _instructorRepository.GetById(instructorId);
        }
        /// <summary>
        /// Returns active instructors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Instructor> GetActiveInstructors()
        {
            return _instructorRepository.GetMany(i => i.IsActive);
        }

        public IEnumerable<Instructor> GetInstructors(Expression<Func<Instructor, bool>> where)
        {
            return _instructorRepository.GetMany(where);
        }

        public IEnumerable<Instructor> Search(string searchText)
        {
            return _instructorRepository.GetMany(i => i.FirstName.Contains(searchText) || i.LastName.Contains(searchText));
        }

        private void SaveInstructor()
        {
            _unitOfWork.Commit();
        }

        public void ActivateInstructor(int instructorId)
        {
            var instructor = _instructorRepository.GetById(instructorId);
            instructor.IsActive = true;
            _instructorRepository.Update(instructor);
            _unitOfWork.Commit();
        }

        public void DeactivateInstructor(int instructorId)
        {
            var instructor = _instructorRepository.GetById(instructorId);
            instructor.IsActive = false;
            _instructorRepository.Update(instructor);
            _unitOfWork.Commit();
        }
    }
}
