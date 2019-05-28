using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TEST2.Models;

namespace TEST2.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public AdminPageController(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        [Authorize(Roles="Admin")]
       /* public IActionResult Index()
        {
          //  ApplicationUserRepository applicationUserRepository = 
            return View();
        }*/

        public ViewResult Index()
        {
            var model = _applicationUserRepository.GetAllApplicationUser();
            ViewBag.PageTitle = "Users List";
            return View(model);
        }
    
        public ViewResult Details(string id)
        {
            ApplicationUser model = _applicationUserRepository.GetApplicationUser(id);
            ViewBag.PageTitle = "Users Details";
            return View(model);
        }
    }
}