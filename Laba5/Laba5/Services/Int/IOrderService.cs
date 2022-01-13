using ClosedXML.Excel;
using Laba5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Laba5.Services.Int
{
    public interface IOrderService : IService<Order>
    {
        XLWorkbook GetWorkbookByOrder(int id);
    }
}
