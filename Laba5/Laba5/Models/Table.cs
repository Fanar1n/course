using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Models
{
    public class Table
    {
        public int Id { get; set; }
        [Display(Name = "Количество мест за столиком")]
        public int NumberOfSeats { get; set; }
        [Display(Name = "Детали столика")]
        public string TableDeatures { get; set; }
    }
}
