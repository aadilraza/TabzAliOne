using SchoolManagementSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Service.Interfaces
{
    public interface ICourseOfferingService
    {
        CourseOffering GetCourseOffering(int courseOfferingId);
        IEnumerable<CourseOffering> GetAllCourseOfferings();
        IEnumerable<CourseOffering> GetCourseOfferings(Expression<Func<CourseOffering, bool>> where);
        IEnumerable<CourseOffering> GetByCourse(int courseId);
        void AssignInstructorToCourseOffering(int instructorId, int courseOfferingId);
        void AssignStudentToCourseOffering(int studentId, int courseOfferingId);
        void DivestStudentFromCourseOffering(int studentId, int courseOfferingId);
        void AssignRoom(int courseOfferingId, int labId);
        int GetHourlyRate(int courseOfferingId, int instructorId);
        void SetHourlyRate(int courseOfferingId, int hourlyRate);
        void CreateCourseOffering(CourseOffering courseOffering);
        void UpdateCourseOffering(CourseOffering courseOffering);
        void DeleteCourseOffering(CourseOffering courseOffering);
        void DeleteCourseOffering(int courseOfferingId);
        void Start(int courseOfferingId);
        void Finish(int courseOfferingId);
        void Cancel(int courseOfferingId);
        int GetHoursElapsed(int courseOfferingId);
        int GetHoursRemaining(int courseOfferingId);
    }
}
