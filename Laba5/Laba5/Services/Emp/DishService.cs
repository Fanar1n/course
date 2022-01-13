using Laba5.Models;
using Laba5.Services.Int;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Services.Emp
{

    public class DishService : IDishService
    {
        private readonly RestaurantContext _db;

        public DishService(RestaurantContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            Dish contract = _db.Dishes.Where(contract => contract.Id == id).FirstOrDefault();
            _db.Dishes.Remove(contract);
            _db.SaveChanges();
        }

        public void Edit(int id, Dish item)
        {
            _db.Dishes.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<Dish> GetAll()
        {
            return _db.Dishes.ToList();
        }

        public Dish GetById(int id)
        {
            return _db.Dishes.Where(contract => contract.Id == id).FirstOrDefault();
        }

        public void Create(Dish item)
        {
            _db.Dishes.Add(item);
            _db.SaveChanges();
        }
    }
}
