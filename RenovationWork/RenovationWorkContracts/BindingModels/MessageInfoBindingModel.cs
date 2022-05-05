using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.BindingModels
{
    /// <summary>
    /// Сообщения, приходящие на почту
    /// </summary>
    public class MessageInfoBindingModel
    {
        public int? ClientId { get; set; }
        public string MessageId { get; set; }
        public string FromMailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateDelivery { get; set; }
        [DataMember]
        public int? ToSkip { get; set; }
        [DataMember]
        public int? ToTake { get; set; }
    }
}
