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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }

        public void CreateStudent(Student student)
        {
            _studentRepository.Add(student);
            SaveStudent();
        }

        public void DeleteStudent(int studentId)
        {
            _studentRepository.Delete(studentId);
            SaveStudent();
        }

        public void DeleteStudent(Student student)
        {
            _studentRepository.Delete(student);
            SaveStudent();
        }

        public void EditStudent(Student student)
        {
            _studentRepository.Update(student);
            SaveStudent();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public IEnumerable<Student> GetByCourse(int courseId)
        {
            var course = _courseRepository.GetById(courseId);
            List<ICollection<Student>> courseOfferingsStudents = course.CourseOfferings.Select(s => s.Students).ToList();
            var students = new List<Student>();
            courseOfferingsStudents.ForEach(s => students.AddRange(s));

            return students;
        }

        public IEnumerable<Student> GetByCourseOffering(int courseOfferingId)
        {
            return _studentRepository.GetMany(s => s.CourseOfferings.Where(c => c.Id == courseOfferingId).Any());
        }
        /// <summary>
        /// Returns all the students that have taken the same course offering(s) with given student
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns></returns>
        public IEnumerable<Student> GetClassmates(int studentId)
        {
            var student = _studentRepository.GetById(studentId);
            var courseOfferings = student.CourseOfferings;
            var students = new List<Student>();
            foreach (var c in courseOfferings)
            {
                students.AddRange(c.Students);
            }
            return students;
        }

        public Student GetStudent(int studentId)
        {
            return _studentRepository.GetById(studentId);
        }

        public IEnumerable<Student> GetStudents(Expression<Func<Student, bool>> where)
        {
            return _studentRepository.GetMany(where);
        }

        public IEnumerable<Student> Search(string searchText)
        {
            return _studentRepository.GetMany(s => s.FirstName.Contains(searchText) || s.LastName.Contains(searchText));
        }

        public IEnumerable<Student> GetRemovedStudents()
        {
            return _studentRepository.GetMany(s => s.IsActive == false);
        }
        /// <summary>
        /// Returns active students
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetActiveStudents()
        {
            return _studentRepository.GetMany(s => s.IsActive);
        }
        /// <summary>
        /// Returns inactive students
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetInactiveStudents()
        {
            return _studentRepository.GetMany(s => s.IsActive == false);
        }
        private void SaveStudent()
        {
            _unitOfWork.Commit();
        }

    }
}
