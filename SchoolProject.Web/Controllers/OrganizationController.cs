using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.DataAccess.Model;
using SchoolProject.Facade.OrganizationFacade;


namespace SchoolProject.Web.Controllers
{
    public class OrganizationController : Controller
    {
        OrganizationFacade _organizationFacade;
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Organizations> organization = new List<Organizations>();
            organization = _organizationFacade.GetAllOrganizations().ToList();
            return View(organization);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(String Name)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = null;
                TempData["Status"] = null;
                var id = new int();
                Organizations organization = new Organizations();
                organization.Id = id;
                organization.Name = Name;
                _organizationFacade.AddNewOrganization(organization);
                TempData["Message"] = "Add is not successfully";
                TempData["Status"] = true;
            }
            else
            {
                TempData["Message"] = "Add is not successfully";
                TempData["Status"] = false;
            }
            var result = _organizationFacade.GetAllOrganizations();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            IEnumerable <Organizations> organization = _organizationFacade.GetAllOrganizations(id);
            if (organization == null)
            {
                return NotFound();
            }
            return View(organization);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind]Organizations organization)
        {
            if (id != organization.Id)
            {
                return null;
            }
            if (ModelState.IsValid)
            {
                _organizationFacade.EditOrganization(organization);
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            IEnumerable <Organizations> organization = _organizationFacade.GetAllOrganizations(id);
            if (organization == null)
            {
                return NotFound();
            }
            return View(organization);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _organizationFacade.DeleteOrganization(id);
            return RedirectToAction("Index");
        }
    }
    
}
