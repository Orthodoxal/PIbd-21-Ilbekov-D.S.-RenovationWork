using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.ViewModels
{
    public class ImplementerViewModel
    {
        public int Id { get; set; }
        [DisplayName("Implementer fullname")]
        public string Fullname { get; set; }
        [DisplayName("Implementer working time")]
        public int WorkingTime { get; set; }
        [DisplayName("Implementer relaxing time")]
        public int PauseTime { get; set; }
    }
}
