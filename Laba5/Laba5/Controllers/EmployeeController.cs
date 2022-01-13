using Laba5.Models;
using Laba5.Services.Int;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeServices;

        public EmployeeController(
        IEmployeeService employeeServices)
        {
            _employeeServices = employeeServices;
        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _employeeServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _employeeServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Employee model)
        {
            _employeeServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _employeeServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _employeeServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            _employeeServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _employeeServices.GetById(id);

            return View("Details", model);
        }
    }
}
