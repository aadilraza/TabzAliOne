using SchoolManagementSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Service.Interfaces
{
    public interface IStudentService
    {
        Student GetStudent(int studentId);
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> GetActiveStudents();
        IEnumerable<Student> GetInactiveStudents();
        IEnumerable<Student> GetStudents(Expression<Func<Student, bool>> where);
        IEnumerable<Student> GetByCourseOffering(int courseOfferingId);
        IEnumerable<Student> GetByCourse(int courseId);
        IEnumerable<Student> Search(string searchText);
        IEnumerable<Student> GetClassmates(int studentId);
        IEnumerable<Student> GetRemovedStudents();
        void CreateStudent(Student student);
        void EditStudent(Student student);
        void DeleteStudent(int studentId);
        void DeleteStudent(Student student);
    }
}
