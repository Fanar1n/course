using Laba5.Models;
using Laba5.Services.Int;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableService _tableServices;

        public TableController(
        ITableService tableServices)
        {
            _tableServices = tableServices;
        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _tableServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _tableServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Table model)
        {
            _tableServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _tableServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _tableServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Table model)
        {
            _tableServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _tableServices.GetById(id);

            return View("Details", model);
        }
    }
}
