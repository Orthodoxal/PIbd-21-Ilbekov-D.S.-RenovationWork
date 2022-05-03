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
        [DisplayName("Sender")]
        public string SenderName { get; set; }
        [DisplayName("Date")]
        public DateTime DateDelivery { get; set; }
        [DisplayName("Header")]
        public string Subject { get; set; }
        [DisplayName("Text")]
        public string Body { get; set; }
    }
}
