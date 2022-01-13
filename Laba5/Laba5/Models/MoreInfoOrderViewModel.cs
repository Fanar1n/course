using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Laba5.Models
{
    public class MoreInfoOrderViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public string Name1 { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public string Name2 { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public string Name3 { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public string Name4 { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public int IdTable { get; set; }

        public DateTime OrderTime { get; set; }

        [Required(ErrorMessage = "Не указано")]
        public string LastName { get; set; }
    }
}
