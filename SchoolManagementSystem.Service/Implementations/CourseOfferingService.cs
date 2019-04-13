using SchoolManagementSystem.Data.Infrastructure.Interfaces;
using SchoolManagementSystem.Data.Repository.Interfaces;
using SchoolManagementSystem.Model.Enums;
using SchoolManagementSystem.Model.Models;
using SchoolManagementSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Service.Implementations
{
    public class CourseOfferingService : ICourseOfferingService
    {
        private readonly ICourseOfferingRepository _courseOfferingRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourseOfferingService(ICourseOfferingRepository courseOfferingRepository, IUnitOfWork unitOfWork, IStudentRepository studentRepository, IInstructorRepository instructorRepository)
        {
            _courseOfferingRepository = courseOfferingRepository;
            _studentRepository = studentRepository;
            _instructorRepository = instructorRepository;
            _unitOfWork = unitOfWork;
        }
        public void AssignInstructorToCourseOffering(int instructorId, int courseOfferingId)
        {
            var courseOffering = _courseOfferingRepository.GetById(courseOfferingId);
            var instructor = _instructorRepository.GetById(instructorId);
            instructor.CourseOfferings.Add(courseOffering);
            _instructorRepository.Update(instructor);
            SaveCourseOffering();
        }

        public void AssignRoom(int courseOfferingId, int roomId)
        {
            var courseOffering = _courseOfferingRepository.GetById(courseOfferingId);
            if (courseOffering != null)
            {
                courseOffering.RoomId = roomId;
                _courseOfferingRepository.Update(courseOffering);
                SaveCourseOffering();
            }
        }

        public void AssignStudentToCourseOffering(int studentId, int courseOfferingId)
        {
            var courseOffering = _courseOfferingRepository.GetById(courseOfferingId);
            var student = _studentRepository.GetById(studentId);
            courseOffering.Students.Add(student);
            _courseOfferingRepository.Update(courseOffering);
            SaveCourseOffering();
        }

        public void Cancel(int courseOfferingId)
        {
            var courseOffering = _courseOfferingRepository.GetById(courseOfferingId);
            if (courseOffering != null)
            {
                courseOffering.State = CourseOfferingState.Canceled;
                _courseOfferingRepository.Update(courseOffering);
                SaveCourseOffering();
            }
        }

        public void CreateCourseOffering(CourseOffering courseOffering)
        {
            _courseOfferingRepository.Add(courseOffering);
            SaveCourseOffering();
        }

        public void DeleteCourseOffering(CourseOffering courseOffering)
        {
            _courseOfferingRepository.Delete(courseOffering);
            SaveCourseOffering();
        }

        public void DeleteCourseOffering(int courseOfferingId)
        {
            _courseOfferingRepository.Delete(courseOfferingId);
            SaveCourseOffering();
        }

        public void DivestStudentFromCourseOffering(int studentId, int courseOfferingId)
        {
            var courseOffering = _courseOfferingRepository.GetById(courseOfferingId);
            var student = _studentRepository.GetById(studentId);
            courseOffering.Students.Remove(student);
            _courseOfferingRepository.Update(courseOffering);
            SaveCourseOffering();
        }

        public void Finish(int courseOfferingId)
        {
            var courseOffering = _courseOfferingRepository.GetById(courseOfferingId);
            if (courseOffering != null)
            {
                courseOffering.State = CourseOfferingState.Finished;
                _courseOfferingRepository.Update(courseOffering);
            }
        }

        public IEnumerable<CourseOffering> GetAllCourseOfferings()
        {
            return _courseOfferingRepository.GetAll().OrderByDescending(c=> c.StartDate);
        }

        public IEnumerable<CourseOffering> GetByCourse(int courseId)
        {
            return _courseOfferingRepository.GetMany(c => c.CourseId == courseId);
        }

        public CourseOffering GetCourseOffering(int courseOfferingId)
        {
            return _courseOfferingRepository.GetById(courseOfferingId);
        }

        public IEnumerable<CourseOffering> GetCourseOfferings(Expression<Func<CourseOffering, bool>> where)
        {
            return _courseOfferingRepository.GetMany(where);
        }

        public int GetHourlyRate(int courseOfferingId, int instructorId)
        {
            var courseOffering = _courseOfferingRepository.GetById(courseOfferingId);
            return courseOffering.HourlyRate;
        }

        public int GetHoursElapsed(int courseOfferingId)
        {
            return _courseOfferingRepository.GetById(courseOfferingId).HoursElapsed;
        }

        public int GetHoursRemaining(int courseOfferingId)
        {
            var elapsed = _courseOfferingRepository.GetById(courseOfferingId).HoursElapsed;
            var duration = _courseOfferingRepository.GetById(courseOfferingId).Course.Duration;
            return duration - elapsed;
        }

        public void SetHourlyRate(int courseOfferingId, int hourlyRate)
        {
            var courseOffering = _courseOfferingRepository.GetById(courseOfferingId);
            courseOffering.HourlyRate = hourlyRate;
            _courseOfferingRepository.Update(courseOffering);
            SaveCourseOffering();
        }

        public void Start(int courseOfferingId)
        {
            var courseOffering = _courseOfferingRepository.GetById(courseOfferingId);
            if (courseOffering != null)
            {
                courseOffering.State = CourseOfferingState.Ongoing;
                _courseOfferingRepository.Update(courseOffering);
                SaveCourseOffering();
            }
        }

        public void UpdateCourseOffering(CourseOffering courseOffering)
        {
            _courseOfferingRepository.Update(courseOffering);
            SaveCourseOffering();
        }
        private void SaveCourseOffering()
        {
            _unitOfWork.Commit();
        }
    }
}
