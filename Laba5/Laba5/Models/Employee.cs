using System.ComponentModel.DataAnnotations;

namespace Laba5.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }
    }
}
