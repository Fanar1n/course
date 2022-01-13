using Laba5.Models;
using Laba5.Services.Int;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishService _dishServices;

        public DishController(
        IDishService dishServices)
        {
            _dishServices = dishServices;
        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _dishServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _dishServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Dish model)
        {
            _dishServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _dishServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _dishServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Dish model)
        {
            _dishServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _dishServices.GetById(id);

            return View("Details", model);
        }
    }
}
