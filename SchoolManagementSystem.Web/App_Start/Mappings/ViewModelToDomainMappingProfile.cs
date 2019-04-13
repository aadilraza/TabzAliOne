using AutoMapper;
using SchoolManagementSystem.Model.Models;
using SchoolManagementSystem.Model.Models.Abstractions;
using SchoolManagementSystem.Web.Models.Course;
using SchoolManagementSystem.Web.Models.CourseOffering;
using SchoolManagementSystem.Web.Models.Person;
using SchoolManagementSystem.Web.Models.Person.Instructor;

namespace SchoolManagementSystem.Web.App_Start.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappingProfile";
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PersonViewModel, Person>();
            CreateMap<CourseViewModel, Course>();
            CreateMap<CourseDetailsViewModel, Course>();
            CreateMap<CourseOfferingDetailsViewModel, CourseOffering>();
            CreateMap<CourseCreateEditViewModel, Course>();
            CreateMap<InstructorDetailsViewModel, Instructor>()
                .ForMember(x => x.Courses, opt => opt.Ignore());
        }
    }
}