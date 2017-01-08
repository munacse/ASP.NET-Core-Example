using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentMngCore.Models;
using StudentMngCore.Repository;
using System.Collections.ObjectModel;

namespace StudentMngCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork unit;
        public HomeController(StudentMngContext context)
        {
            unit = new UnitOfWork(context);
        }
        public IActionResult Index()
        {
            var student = unit.StudentRepository.Find(2);
            //
            //var student = new Student()
            //{
            //    Name = "James Bond",
            //    Email = "james@gmail.com",
            //    ConNumber = "01737240989",
            //    Roll = "C0919505",
            //    Age = 23,
            //    StudentCourses = new Collection<StudentCourse>()
            //    {
            //        new StudentCourse() { CourseId =1},
            //        new StudentCourse() { CourseId =2}

            //    }
            //};
            //unit.StudentRepository.InsertOrUpdate(student);
            //unit.StudentRepository.Save();
            //
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
