using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.BindingModels
{
    public class ImplementerBindingModel
    {
        public int? Id { get; set; }
        public string Fullname { get; set; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
    }
}
