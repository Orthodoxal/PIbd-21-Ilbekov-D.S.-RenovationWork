using RenovationWorkContracts.Attributes;
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
        [Column(title: "Implementer fullname", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Fullname { get; set; }
        [Column(title: "Implementer working time", width: 70)]
        public int WorkingTime { get; set; }
        [Column(title: "Implementer relaxing time", width: 70)]
        public int PauseTime { get; set; }
    }
}
