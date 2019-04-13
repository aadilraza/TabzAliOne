using AutoMapper;
using SchoolManagementSystem.Model.Enums;
using SchoolManagementSystem.Model.Models;
using SchoolManagementSystem.Service.Implementations;
using SchoolManagementSystem.Service.Interfaces;
using SchoolManagementSystem.Web.Core.Extensions;
using SchoolManagementSystem.Web.Models.CourseOffering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Web.Controllers
{
    public class CourseOfferingsController : Controller
    {
        private readonly ICourseOfferingService _courseOfferingService;
        private readonly IInstructorService _instructorService;
        private readonly ICourseService _courseService;
        private readonly IRoomService _roomService;
        public CourseOfferingsController(ICourseOfferingService courseOfferingService, ICourseService courseService, IRoomService roomService, IInstructorService instructorService)
        {
            _courseOfferingService = courseOfferingService;
            _courseService = courseService;
            _roomService = roomService;
            _instructorService = instructorService;
        }
        // GET: CourseOfferings
        public ActionResult Index()
        {
            var courseOfferings = _courseOfferingService.GetAllCourseOfferings().ToList();
            var model = Mapper.Map<IEnumerable<CourseOffering>, IEnumerable<CourseOfferingViewModel>>(courseOfferings);
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CourseOfferingDetailsViewModel
            {
                Courses = _courseService.GetCourses(c => c.IsActive).ToSelectListItems(c => c.Title, c => c.Id.ToString()),
                Rooms = _roomService.GetAllRooms().ToSelectListItems(r => r.Name, r => r.Id.ToString()),
                Instructors = _instructorService.GetActiveInstructors().ToSelectListItems(i => i.FullName, i => i.Id.ToString()),
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CourseOfferingDetailsViewModel model)
        {
            var courseOffering = Mapper.Map<CourseOfferingViewModel, CourseOffering>(model);
            _courseOfferingService.CreateCourseOffering(courseOffering);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var courseOffering = _courseOfferingService.GetCourseOffering(id);
            var model = Mapper.Map<CourseOffering, CourseOfferingDetailsViewModel>(courseOffering);
            model.Courses = _courseService.GetCourses(c => c.IsActive).ToSelectListItems(c => c.Title, c => c.Id.ToString());
            model.Rooms = _roomService.GetAllRooms().ToSelectListItems(r => r.Name, r => r.Id.ToString());
            model.Instructors = _instructorService.GetActiveInstructors().ToSelectListItems(i => i.FullName, i => i.Id.ToString());
            return View(model);
        }
    }
}