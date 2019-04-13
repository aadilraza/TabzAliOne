namespace SchoolManagementSystem.Service.Interfaces
{
    public interface ICourseInstructorService
    {
        void AssignInstructorToCourse(int instructorId, int courseId);
        void DivestInstructorFromCourse(int instructorId, int courseId);
    }
}
