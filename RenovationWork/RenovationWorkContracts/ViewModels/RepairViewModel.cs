using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class RepairViewModel
    {
        public int Id { get; set; }
        [DisplayName("Repair name")]
        public string RepairName { get; set; }
        [DisplayName("Price")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> RepairComponents { get; set; }
    }
}
