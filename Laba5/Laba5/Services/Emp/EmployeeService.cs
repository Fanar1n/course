using Laba5.Models;
using Laba5.Services.Int;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Services.Emp
{

    public class EmployeeService : IEmployeeService
    {
        private readonly RestaurantContext _db;

        public EmployeeService(RestaurantContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            Employee contract = _db.Employees.Where(contract => contract.Id == id).FirstOrDefault();
            _db.Employees.Remove(contract);
            _db.SaveChanges();
        }

        public void Edit(int id, Employee item)
        {
            _db.Employees.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _db.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _db.Employees.Where(contract => contract.Id == id).FirstOrDefault();
        }

        public void Create(Employee item)
        {
            _db.Employees.Add(item);
            _db.SaveChanges();
        }
    }
}
