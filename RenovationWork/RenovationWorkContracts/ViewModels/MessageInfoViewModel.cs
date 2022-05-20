using RenovationWorkContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.ViewModels
{
    public class MessageInfoViewModel
    {
        public string MessageId { get; set; }
        [Column(title: "Sender", width: 100)]
        public string SenderName { get; set; }
        [Column(title: "Date", width: 100)]
        public DateTime DateDelivery { get; set; }
        [Column(title: "Header", width: 100)]
        public string Subject { get; set; }
        [Column(title: "Text", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Body { get; set; }
    }
}
