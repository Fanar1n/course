using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Laba5.Models
{
    public class AddOrderViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public int IdDish1 { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public int IdDish2 { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public int IdDish3 { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public int IdDish4 { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public int IdTable { get; set; }
        public double OrderAmount { get; set; }
        public int LeadTime { get; set; }

        public DateTime OrderTime { get; set; }

        [Required(ErrorMessage = "Не указано")]
        public string LastName { get; set; }

    }
}
