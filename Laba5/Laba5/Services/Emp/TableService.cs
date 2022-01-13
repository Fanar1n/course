using Laba5.Models;
using Laba5.Services.Int;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Services.Emp
{

    public class TableService : ITableService
    {
        private readonly RestaurantContext _db;

        public TableService(RestaurantContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            Table contract = _db.Tables.Where(contract => contract.Id == id).FirstOrDefault();
            _db.Tables.Remove(contract);
            _db.SaveChanges();
        }

        public void Edit(int id, Table item)
        {
            _db.Tables.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<Table> GetAll()
        {
            return _db.Tables.ToList();
        }

        public Table GetById(int id)
        {
            return _db.Tables.Where(contract => contract.Id == id).FirstOrDefault();
        }

        public void Create(Table item)
        {
            _db.Tables.Add(item);
            _db.SaveChanges();
        }
    }
}
