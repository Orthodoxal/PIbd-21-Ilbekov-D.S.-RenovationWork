using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.ViewModels
{
    /// <summary>
    /// Склад
    /// </summary>
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Warehouse name")]
        public string WarehouseName { get; set; }
        [DisplayName("Responsible Full Name")]
        public string ResponsibleFullName { get; set; }
        [DisplayName("Date create")]
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
