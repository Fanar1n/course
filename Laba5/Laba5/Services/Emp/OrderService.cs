using ClosedXML.Excel;
using Laba5.Models;
using Laba5.Services.Int;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Services.Emp
{

    public class OrderService : IOrderService
    {
        private readonly RestaurantContext _db;
        private XLWorkbook _xLWorkbook;

        public OrderService(RestaurantContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            Order contract = _db.Orders.Where(contract => contract.Id == id).FirstOrDefault();
            _db.Orders.Remove(contract);
            _db.SaveChanges();
        }

        public void Edit(int id, Order item)
        {
            _db.Orders.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders
                .Include(x =>x.Dish)
                .Include(x=>x.Table)
                .AsNoTracking()
                .ToList();
        }

        public Order GetById(int id)
        {
            return _db.Orders
                .Where(contract => contract.Id == id)
                .Include(x => x.Dish)
                .Include(x=> x.Table)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public void Create(Order item)
        {
            _db.Orders.Add(item);
            _db.SaveChanges();
        }

        private void FeelWorkBook(IEnumerable<Order> perf)
        {
            var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Услуги");
            var currentRow = 1;

            worksheet.Cell(currentRow, 1).Value = "id";
            worksheet.Cell(currentRow, 2).Value = "Первое блюдо";
            worksheet.Cell(currentRow, 3).Value = "Второе блюдо";
            worksheet.Cell(currentRow, 4).Value = "Третье блюдо";
            worksheet.Cell(currentRow, 5).Value = "Четвертое блюдо";
            worksheet.Cell(currentRow, 6).Value = "Столик";
            worksheet.Cell(currentRow, 7).Value = "Фамилия клиента";
            worksheet.Cell(currentRow, 8).Value = "Сумма заказа";
            worksheet.Cell(currentRow, 9).Value = "Время заказа";

            foreach (var per in perf)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = per.Id;
                worksheet.Cell(currentRow, 2).Value = per.Dish?.NameDish;
                worksheet.Cell(currentRow, 3).Value = per.Dish?.NameDish ?? "нет данных";
                worksheet.Cell(currentRow, 4).Value = per.Dish?.NameDish ?? "нет данных";
                worksheet.Cell(currentRow, 5).Value = per.Dish?.NameDish ?? "нет данных";
                worksheet.Cell(currentRow, 6).Value = per.Table.Id;
                worksheet.Cell(currentRow, 7).Value = per.LastName ?? "нет данных";
                worksheet.Cell(currentRow, 8).Value = per.OrderAmount;
                worksheet.Cell(currentRow, 9).Value = per.OrderTime;
            }

            _xLWorkbook = workbook;
        }


        public XLWorkbook GetWorkbookByOrder(int orderId)
        {
            var perf = GetAll();

            perf = perf.Where(x => x.Id == orderId);

            FeelWorkBook(perf);

            return _xLWorkbook;
        }
    }
}
