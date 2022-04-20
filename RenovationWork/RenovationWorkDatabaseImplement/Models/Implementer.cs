using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkDatabaseImplement.Models
{
    public class Implementer
    {
        public int Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public int WorkingTime { get; set; }
        [Required]
        public int PauseTime { get; set; }
        [ForeignKey("ImplementerId")]
        public virtual List<Order> Orders { get; set; }
    }
}
