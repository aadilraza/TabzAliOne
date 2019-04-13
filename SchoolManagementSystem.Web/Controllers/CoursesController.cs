using AutoMapper;
using SchoolManagementSystem.Model.Models;
using SchoolManagementSystem.Service.Interfaces;
using SchoolManagementSystem.Web.Core.Extensions;
using SchoolManagementSystem.Web.Models.Course;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SchoolManagementSystem.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IInstructorService _instructorService;
        private readonly ICourseService _courseService;
        private readonly ICourseInstructorService _courseInstructorService;
        private readonly ICategoryService _categoryService;

        public CoursesController(IInstructorService instructorService, ICourseService courseService, ICourseInstructorService courseInstructorService, ICategoryService categoryService)
        {
            _instructorService = instructorService;
            _courseService = courseService;
            _courseInstructorService = courseInstructorService;
            _categoryService = categoryService;
        }

        // GET: Courses
        public ActionResult Index()
        {
            var courses = _courseService.GetAllCourses();
            var model = Mapper.Map<IEnumerable<Course>, List<CourseViewModel>>(courses);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var course = Mapper.Map<Course, CourseDetailsViewModel>(_courseService.GetCourse(id));
            return View(course);
        }

        public ActionResult Edit(int id)
        {
            var course = _courseService.GetCourse(id);
            var model = Mapper.Map<Course, CourseCreateEditViewModel>(course);
            model.Categories = _categoryService.GetAllCategories().ToSelectListItems(c => c.Name, c => c.Id.ToString());
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CourseCreateEditViewModel model)
        {
            var course = Mapper.Map<CourseCreateEditViewModel, Course>(model);
            _courseService.EditCourse(course);

            return RedirectToAction("Index");
        }

        public ActionResult Activate(int id)
        {
            var course = _courseService.GetCourse(id);
            _courseService.ActivateCourse(id);
            return RedirectToAction("Index");
        }
        public ActionResult Deactivate(int id)
        {
            var course = _courseService.GetCourse(id);
            _courseService.DeactivateCourse(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var model = new CourseCreateEditViewModel();
            model.Categories = _categoryService.GetAllCategories().ToSelectListItems(c => c.Name, c => c.Id.ToString());
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CourseCreateEditViewModel model)
        {
            var course = Mapper.Map<CourseCreateEditViewModel, Course>(model);
            _courseService.CreateCourse(course);

            return RedirectToAction("Index");
        }
    }
}