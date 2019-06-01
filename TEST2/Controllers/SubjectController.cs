using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TEST2.Data;
using TEST2.Models.SubjectRepo;
using TEST2.ViewModels;

namespace TEST2.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")] 
        public ViewResult Index()
        {
            var model = _subjectRepository.GetAllSubject();
            ViewBag.PageTitle = "Subject List";
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int Id)
        {
            _subjectRepository.Delete(Id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            ViewBag.PageTitle = "Edit Subject";
            Subject subject = _subjectRepository.GetSubject(Id);
            SubjectEditViewModel subjectEditViewModel = new SubjectEditViewModel
            {
                Id = subject.Id,
                SubjectName = subject.SubjectName,
                TeacherId = subject.TeacherId,
                Teacher = subject.Teacher
            };
            return View(subjectEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(SubjectEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Subject subject = _subjectRepository.GetSubject(model.Id);

                subject.SubjectName = model.SubjectName;
                subject.TeacherId = model.TeacherId;

                _subjectRepository.Update(subject);

                return RedirectToAction("index");
            }

            return View(model);
        }


        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.PageTitle = "Create user";
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubjectCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Subject newSubject = new Subject
                {
                    SubjectName = model.SubjectName,
                    TeacherId = model.TeacherId,
                    Teacher = model.Teacher
                };

                _subjectRepository.Create(newSubject);
                return RedirectToAction("index", new { id = newSubject.Id });
            }

            return View();
        }


    }
}