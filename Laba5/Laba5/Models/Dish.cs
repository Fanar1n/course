using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Models
{
    public class Dish
    {
        public int Id { get; set; }

        [Display(Name="Название блюда")]
        public string NameDish { get; set; }
        [Display(Name = "Время готовки")]
        public int CookTime { get; set; }
        [Display(Name = "Цена")]
        public double Price { get; set; }
    }
}
