using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TEST2.Models;
using TEST2.ViewModels;

namespace TEST2.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public AdminPageController(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }


        /* public IActionResult Index()
         {
           //  ApplicationUserRepository applicationUserRepository = 
             return View();
         }*/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            var model = _applicationUserRepository.GetAllApplicationUser();
            ViewBag.PageTitle = "Users List";
            return View(model);
        }

        [HttpGet]
        public ViewResult Details(string id)
        {
            ViewBag.PageTitle = "Users Details";
            ApplicationUser model = _applicationUserRepository.GetApplicationUser(id);            
            return View(model);
        }

        [HttpGet]
        public ViewResult Edit(string Id)
        {
            ViewBag.PageTitle = "Edit user";
            ApplicationUser applicationUser = _applicationUserRepository.GetApplicationUser(Id);
            ApplicationUserEditViewModel applicationUserEditViewModel = new ApplicationUserEditViewModel
            {
                Id = applicationUser.Id,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Pesel = applicationUser.Pesel,
                DateOfBirth = applicationUser.DateOfBirth,
                Email = applicationUser.Email

            };
            return View(applicationUserEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationUserEditViewModel model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the employee being edited from the database
                ApplicationUser applicationUser = _applicationUserRepository.GetApplicationUser(model.Id);
                // Update the employee object with the data in the model object
                applicationUser.FirstName = model.FirstName;
                applicationUser.LastName = model.LastName;
                applicationUser.Pesel = model.Pesel;
                applicationUser.DateOfBirth = model.DateOfBirth;
                applicationUser.Email = model.Email;

                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                //ApplicationUser updatedApplicationUser = 
                    _applicationUserRepository.Update(applicationUser);

                return RedirectToAction("index");
            }

            return View(model);
        }

        public IActionResult Delete(string Id)
        {
            //ApplicationUser applicationUser = _applicationUserRepository.GetApplicationUser(Id);
            _applicationUserRepository.Delete(Id);
            return RedirectToAction("index");
        }
    }
}