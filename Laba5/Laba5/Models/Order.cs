using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Models
{
    public class Order
    {
        //public int Id { get; set; }
        //[Display(Name = "Фамилия")]
        //public string LastName { get; set; }
        //[Display(Name = "Время ожидания заказа")]
        //public DateTime LeadTime {get; set;}  //Время выполнения заказа
        //[Display(Name = "Сумма заказа")]
        //public double OrderAmount { get; set; } //Сумма заказа
        //[Display(Name = "Время заказа")]
        //public DateTime OrderTime { get; set; }  //Время когда был сделан заказ
        //public int DishId { get; set; }
        //public Dish Dish { get; set; }
        //public int TableId { get; set; }
        //public Table Table { get; set; }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не выбрано блюдо")]
        [Display(Name = "Название блюда")]
        public int IdDish1 { get; set; }
        [ForeignKey(nameof(IdDish1))]
        [Required(ErrorMessage = "Не выбрано блюдо")]
        [Display(Name = "Название блюда")]
        public int IdDish2 { get; set; }
        [ForeignKey(nameof(IdDish2))]
        [Required(ErrorMessage = "Не выбрано блюдо")]
        [Display(Name = "Название блюда")]
        public int IdDish3 { get; set; }
        [ForeignKey(nameof(IdDish3))]
        [Required(ErrorMessage = "Не выбрано блюдо")]
        [Display(Name = "Название блюда")]
        public int IdDish4 { get; set; }
        [ForeignKey(nameof(IdDish4))]
        public Dish Dish { get; set; }

        [Required(ErrorMessage = "Не выбран столик")]
        [Display(Name = "Столик")]
        public int IdTable { get; set; }
        [ForeignKey(nameof(IdTable))]
        public Table Table { get; set; }

        [Required(ErrorMessage = "Не выбрана услуга")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не выбрана услуга")]
        [Display(Name = "Время заказа")]
        public DateTime OrderTime { get; set; }
        [Display(Name = "Сумма заказа")]
        public double OrderAmount { get; set; }
        [Display(Name = "Время приготовления заказа")]
        public int LeadTime { get; set; }
        public List<Dish> Dishes { get; set; }

    }
}
