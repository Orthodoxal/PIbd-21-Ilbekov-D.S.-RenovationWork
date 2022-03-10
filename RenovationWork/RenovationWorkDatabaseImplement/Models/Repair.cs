﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkDatabaseImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Repair
    {
        public int Id { get; set; }
        [Required]
        public string RepairName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("RepairId")]
        public virtual List<RepairComponent> RepairComponents { get; set; }
        [ForeignKey("RepairId")]
        public virtual List<Order> Orders { get; set; }
    }
}
