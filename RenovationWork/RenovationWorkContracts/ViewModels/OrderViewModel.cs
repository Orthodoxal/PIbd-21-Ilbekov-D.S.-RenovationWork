using RenovationWorkContracts.Attributes;
using RenovationWorkContracts.Enums;
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
        public int? ImplementerId { get; set; }
        [Column(title: "Implementer fullname", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFullname{ get; set; }
        [Column(title: "Client fullname", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFullname { get; set; }
        [Column(title: "Repair", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string RepairName { get; set; }
        [Column(title: "Amount", width: 60)]
        public int Count { get; set; }
        [Column(title: "Total", width: 50)]
        public decimal Sum { get; set; }
        [Column(title: "Status", width: 50)]
        public OrderStatus Status { get; set; }
        [Column(title: "Date Create", gridViewAutoSize: GridViewAutoSize.Fill)]
        public DateTime DateCreate { get; set; }
        [Column(title: "Date Implement", gridViewAutoSize: GridViewAutoSize.Fill)]
        public DateTime? DateImplement { get; set; }
    }
}
