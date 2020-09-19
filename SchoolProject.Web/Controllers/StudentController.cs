using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.DataAccess.Model;
using SchoolProject.Facade.OrganizationFacade;
using SchoolProject.Facade.StudentFacade;

namespace SchoolProject.Web.Controllers
{
    public class StudentController : Controller
    {
        StudentFacade _studentFacade;
        OrganizationFacade _organizationFacade;
        // GET: /<controller>/
        // string connectionString = 
        public IActionResult Index()
        {
            List<Students> student = new List<Students>();
            student = _studentFacade.GetAllStudents().ToList();
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string NameSurname,string orgName)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = null;
                TempData["Status"] = null;
                var id = new int();
                Students student = new Students();
                student.Id = id;
                student.NameSurname = NameSurname;
                student.OrganizationId =_organizationFacade.GetOrganizationIByName(orgName).Id;
                _studentFacade.AddNewStudent(student);
                TempData["Message"] = "Add is not successfully";
                TempData["Status"] = true;
            }
            else
            {
                TempData["Message"] = "Add is not successfully";
                TempData["Status"] = false;
            }
            var result = _studentFacade.GetAllStudents();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            IEnumerable<Students> student = _studentFacade.GetAllStudents(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Students student)
        {
            if (id != student.Id)
            {
                return null;
            }
            if (ModelState.IsValid)
            {
                _studentFacade.EditStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            IEnumerable<Students> student = _studentFacade.GetAllStudents(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _studentFacade.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
