using AutoMapper;
using AutoMapper.Mappers;
using SchoolManagementSystem.Model.Models;
using SchoolManagementSystem.Model.Models.Abstractions;
using SchoolManagementSystem.Web.Models;
using SchoolManagementSystem.Web.Models.Course;
using SchoolManagementSystem.Web.Models.CourseOffering;
using SchoolManagementSystem.Web.Models.Person;
using SchoolManagementSystem.Web.Models.Person.Instructor;
using System.Linq;

namespace SchoolManagementSystem.Web.App_Start.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappingProfile";
        public DomainToViewModelMappingProfile()
        {
            AddConditionalObjectMapper().Where((s, d) => s.Namespace != "System.Data.Entity.DynamicProxies" && d.Namespace != "System.Data.Entity.DynamicProxies");

            CreateMap<Person, PersonViewModel>();

            CreateMap<Instructor, InstructorDetailsViewModel>()
                 .ForMember(x => x.Courses, opt => opt.Ignore());

            CreateMap<Course, CourseViewModel>();

            CreateMap<Course, CourseDetailsViewModel>()
                .ForMember(
                dest => dest.Category,
                opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(x => x.SubCourses, opt => opt.Ignore());

            CreateMap<Course, CourseCreateEditViewModel>();

            //Courses of the instructor
            CreateMap<Course, CheckBoxListItem>()
                .ForMember(
                dest => dest.Display,
                opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.IsChecked,
                opt => opt.ResolveUsing(
                 (src, dest, destMember, resContext) =>
                 dest.IsChecked = src.Instructors.Where(i => i.Id == (int)resContext.Items["instructorId"]).Any()));

            CreateMap<CourseOffering, CourseOfferingViewModel>()
               .ForMember(
                dest => dest.Instructor,
                opt => opt.MapFrom(src => src.Instructor.FullName))
                .ForMember(dest => dest.Room
                , opt => opt.MapFrom(src => src.Room.Name))
                .ForMember(dest => dest.StudentsCount
                , opt => opt.MapFrom(src => src.Students.Count))
                .ForMember(
                dest => dest.Course,
                opt => opt.MapFrom(src => src.Course.Title))
                . ForMember(dest=> dest.Days,
                opt=> opt.Ignore());

            CreateMap<CourseOffering, CourseOfferingDetailsViewModel>()
                .ForMember(x => x.Courses, opt => opt.Ignore())
                .ForMember(x=> x.Instructors, opt=> opt.Ignore())
                .ForMember(x=> x.Rooms, opt=> opt.Ignore());
        }
    }
}