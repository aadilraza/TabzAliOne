using AutoMapper;
using SchoolManagementSystem.Model.Models;
using SchoolManagementSystem.Service.Interfaces;
using SchoolManagementSystem.Web.Core.Extensions;
using SchoolManagementSystem.Web.Models;
using SchoolManagementSystem.Web.Models.Person;
using SchoolManagementSystem.Web.Models.Person.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Web.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IInstructorService _instructorService;
        private readonly ICourseService _courseService;
        private readonly ICityService _cityService;
        private readonly ICourseInstructorService _courseInstructorService;
        public InstructorsController(IInstructorService instructorService, ICourseService courseService, ICityService cityService, ICourseInstructorService courseInstructorService)
        {
            _instructorService = instructorService;
            _courseService = courseService;
            _cityService = cityService;
            _courseInstructorService = courseInstructorService;
        }
        // GET: Instructors
        public ActionResult Index()
        {
            var instructors = _instructorService.GetAllInstructors();
            var model = Mapper.Map<IEnumerable<Instructor>, List<PersonViewModel>>(instructors);
            return View(model);
        }
        public ActionResult Create()
        {
            var model = new InstructorDetailsViewModel();
            var allCourses = _courseService.GetAllCourses();
            model.Courses = Mapper.Map<IEnumerable<Course>, List<CheckBoxListItem>>(allCourses);
            model.Cities = _cityService.GetCities().ToSelectListItems(c => c.Name, c => c.Id.ToString());

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(InstructorDetailsViewModel model)
        {
            var instructor = Mapper.Map<InstructorDetailsViewModel, Instructor>(model);
            _instructorService.CreateInstructor(instructor);
            var assignedCourses = model.Courses.Where(x => x.IsChecked).Select(x => x.Id).ToList();
            assignedCourses.ForEach(c => _courseInstructorService.AssignInstructorToCourse(instructor.Id, c));

            return RedirectToAction("Index");

        }
        public ActionResult Activate(int id)
        {
            _instructorService.ActivateInstructor(id);
            return RedirectToAction("Index");
        }
        public ActionResult Deactivate(int id)
        {
            _instructorService.DeactivateInstructor(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var instructor = _instructorService.GetInstructor(id);
            var model = Mapper.Map<Instructor, InstructorDetailsViewModel>(instructor);
            var allCourses = _courseService.GetAllCourses();
            model.Courses = Mapper.Map<IEnumerable<Course>, List<CheckBoxListItem>>(allCourses,
                opts => opts.Items["instructorId"] = id);
            model.Cities = _cityService.GetCities().ToSelectListItems(c => c.Name, c => c.Id.ToString());

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(InstructorDetailsViewModel model)
        {
            var instructor = Mapper.Map<InstructorDetailsViewModel, Instructor>(model);
            //Person properties
            _instructorService.EditInstructor(instructor);

            #region Assign and divest courses
            var assignedCourses = model.Courses.Where(x => x.IsChecked).Select(x => x.Id).ToList();
            var divestedCourses = model.Courses.Where(x => !x.IsChecked).Select(x => x.Id).ToList();
            assignedCourses.ForEach(c => _courseInstructorService.AssignInstructorToCourse(instructor.Id, c));
            divestedCourses.ForEach(c => _courseInstructorService.DivestInstructorFromCourse(instructor.Id, c));
            #endregion

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var instructor = _instructorService.GetInstructor(id);
            var model = Mapper.Map<Instructor, InstructorDetailsViewModel>(instructor);
            var allCourses = _courseService.GetAllCourses();
            model.Courses = Mapper.Map<IEnumerable<Course>, List<CheckBoxListItem>>(allCourses,
                opts => opts.Items["instructorId"] = id)
                .Where(c => c.IsChecked).ToList();
            ViewBag.City = _cityService.GetCity(model.CityId).Name;
            return View(model);
        }
    }
}