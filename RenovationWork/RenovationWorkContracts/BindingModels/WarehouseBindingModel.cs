using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.BindingModels
{
    /// <summary>
    /// Склад
    /// </summary>
    public class WarehouseBindingModel
    {
        public int? Id { get; set; }
        public string WarehouseName { get; set; }
        public string ResponsibleFullName { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
