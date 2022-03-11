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
    /// Склад
    /// </summary>
    public class Warehouse
    {
        public int Id { get; set; }
        [Required]
        public string WarehouseName { get; set; }
        [Required]
        public string ResponsibleFullName { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual List<WarehouseComponent> WarehouseComponents { get; set; }
    }
}
