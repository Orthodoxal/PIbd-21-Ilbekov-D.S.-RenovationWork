using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class RepairBindingModel
    {
        public int? Id { get; set; }
        public string RepairName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}
