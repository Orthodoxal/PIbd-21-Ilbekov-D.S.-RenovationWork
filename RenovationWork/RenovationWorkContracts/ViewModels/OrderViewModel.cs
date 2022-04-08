﻿using RenovationWorkContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int RepairId { get; set; }
        public int ClientId { get; set; }
        [DisplayName("Client fullname")]
        public string ClientFullname { get; set; }
        [DisplayName("Repair")]
        public string RepairName { get; set; }
        [DisplayName("Amount")]
        public int Count { get; set; }
        [DisplayName("Total")]
        public decimal Sum { get; set; }
        [DisplayName("Status")]
        public OrderStatus Status { get; set; }
        [DisplayName("Date Create")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Date Implement")]
        public DateTime? DateImplement { get; set; }
    }
}
