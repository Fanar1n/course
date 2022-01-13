using Laba5.Models;
using Laba5.Services.Int;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace Laba5.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderServices;
        private readonly IDishService _dishServices;
        private readonly ITableService _tableService;
        private readonly IEmployeeService _employeeService;
        private readonly RestaurantContext _db;
        private XLWorkbook _xLWorkbook;

        public OrderController(IDishService dishServices,
        ITableService tableService,
        IOrderService orderServices)
        {
            _tableService = tableService;
            _dishServices = dishServices;
            _orderServices = orderServices;
        }

        // GET: ProductController/Index
        public IActionResult Index(string sortOrder)
        {
            var model = _orderServices.GetAll();
            ViewBag.Order = new SelectList(_orderServices.GetAll(), "Id", "Id");

            switch (sortOrder)
            {
                case "order_desc":
                    model = model.OrderByDescending(s => s.OrderTime);
                    break;
                case "order_asc":
                    model = model.OrderBy(s => s.OrderTime);
                    break;
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var dish1 = _dishServices.GetAll();
            ViewBag.Dishes1 = new SelectList(dish1, "Id", "NameDish");
            var dish2 = _dishServices.GetAll();
            ViewBag.Dishes2 = new SelectList(dish2, "Id", "NameDish");
            var dish3 = _dishServices.GetAll();
            ViewBag.Dishes3 = new SelectList(dish3, "Id", "NameDish");
            var dish4 = _dishServices.GetAll();
            ViewBag.Dishes4 = new SelectList(dish4, "Id", "NameDish");
            var tables = _tableService.GetAll();
            ViewBag.Tables = new SelectList(tables, "Id", "TableDeatures");

            return View();
        }

        [HttpPost]
        public IActionResult Add(AddOrderViewModel model)
        {
            var price1 = _dishServices.GetById(model.IdDish1).Price;
            var price2 = _dishServices.GetById(model.IdDish2).Price;
            var price3 = _dishServices.GetById(model.IdDish3).Price;
            var price4 = _dishServices.GetById(model.IdDish4).Price;
            var price = price1 + price2 + price3 + price4;

            if (price >= 50)
            {
                price = price * 0.85;
            }
            else if (price >= 40)
            {
                price = price * 0.90;
            }
            else if (price >= 30)
            {
                price = price * 0.95;
            }

            model.OrderAmount = price;

            var leadTime1 = _dishServices.GetById(model.IdDish1).CookTime;
            var leadTime2 = _dishServices.GetById(model.IdDish2).CookTime;
            var leadTime3 = _dishServices.GetById(model.IdDish3).CookTime;
            var leadTime4 = _dishServices.GetById(model.IdDish4).CookTime;
            var leadTime = (leadTime1 + leadTime2 + leadTime3 + leadTime4) / 2;
            model.LeadTime = leadTime;

            var order = new Order
            {
                Id = model.Id,
                IdDish1 = model.IdDish1,
                IdDish2 = model.IdDish2,
                IdDish3 = model.IdDish3,
                IdDish4 = model.IdDish4,
                IdTable = model.IdTable,
                OrderTime = DateTime.Now,
                LastName = model.LastName,
                OrderAmount = model.OrderAmount,
                LeadTime = model.LeadTime
            };

            _orderServices.Create(order);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            _orderServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dish1 = _dishServices.GetAll();
            ViewBag.Dishes1 = new SelectList(dish1, "Id", "NameDish");
            var dish2 = _dishServices.GetAll();
            ViewBag.Dishes2 = new SelectList(dish2, "Id", "NameDish");
            var dish3 = _dishServices.GetAll();
            ViewBag.Dishes3 = new SelectList(dish3, "Id", "NameDish");
            var dish4 = _dishServices.GetAll();
            ViewBag.Dishes4 = new SelectList(dish4, "Id", "NameDish");
            var tables = _tableService.GetAll();
            ViewBag.Tables = new SelectList(tables, "Id", "TableDeatures");

            var model = _orderServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Order model)
        {

            var price1 = _dishServices.GetById(model.IdDish1).Price;
            var price2 = _dishServices.GetById(model.IdDish2).Price;
            var price3 = _dishServices.GetById(model.IdDish3).Price;
            var price4 = _dishServices.GetById(model.IdDish4).Price;
            var price = price1 + price2 + price3 + price4;

            if (price >= 50)
            {
                price = price * 0.85;
            }
            else if (price >= 40)
            {
                price = price * 0.90;
            }
            else if (price >= 30)
            {
                price = price * 0.95;
            }

            model.OrderAmount = price;

            var leadTime1 = _dishServices.GetById(model.IdDish1).CookTime;
            var leadTime2 = _dishServices.GetById(model.IdDish2).CookTime;
            var leadTime3 = _dishServices.GetById(model.IdDish3).CookTime;
            var leadTime4 = _dishServices.GetById(model.IdDish4).CookTime;
            var leadTime = (leadTime1 + leadTime2 + leadTime3 + leadTime4) / 2;
            model.LeadTime = leadTime;

            var order = new Order
            {
                Id = model.Id,
                IdDish1 = model.IdDish1,
                IdDish2 = model.IdDish2,
                IdDish3 = model.IdDish3,
                IdDish4 = model.IdDish4,
                IdTable = model.IdTable,
                OrderTime = DateTime.Now,
                LastName = model.LastName,
                OrderAmount = model.OrderAmount,
                LeadTime = model.LeadTime
            };
            _orderServices.Edit(model.Id, order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _orderServices.GetById(id);
            ViewBag.Dish1 = _dishServices.GetById(model.IdDish1).NameDish;
            ViewBag.Dish2 = _dishServices.GetById(model.IdDish2).NameDish;
            ViewBag.Dish3 = _dishServices.GetById(model.IdDish3).NameDish;
            ViewBag.Dish4 = _dishServices.GetById(model.IdDish4).NameDish;
            return View("Details", model);
        }

        [HttpGet]
        public IActionResult Download(int orderId)
        {
            _xLWorkbook = _orderServices.GetWorkbookByOrder(orderId);

            using var stream = new MemoryStream();
            _xLWorkbook.SaveAs(stream);
            var content = stream.ToArray();

            _xLWorkbook.Dispose();
            return File(content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Чек.xlsx");
        }
    }
}