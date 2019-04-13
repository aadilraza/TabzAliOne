using SchoolManagementSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Service.Interfaces
{
    public interface IInstructorService
    {
        Instructor GetInstructor(int instructorId);
        IEnumerable<Instructor> GetAllInstructors();
        IEnumerable<Instructor> GetActiveInstructors();
        IEnumerable<Instructor> GetInactiveInstructors();
        IEnumerable<Instructor> GetInstructors(Expression<Func<Instructor, bool>> where);
        IEnumerable<Instructor> GetByCourseOffering(int courseOfferingId);
        IEnumerable<Instructor> GetByCourse(int courseId);
        IEnumerable<Instructor> Search(string searchText);
        void ActivateInstructor(int instructorId);
        void DeactivateInstructor(int instructorId);
        void CreateInstructor(Instructor instructor);
        void EditInstructor(Instructor instructor);
        void DeleteInstructor(int instructorId);
        void DeleteInstructor(Instructor instructor);
    }
}
