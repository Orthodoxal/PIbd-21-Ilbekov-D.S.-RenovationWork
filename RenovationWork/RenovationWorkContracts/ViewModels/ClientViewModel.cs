using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [DisplayName("Client fullname")]
        public string Fullname { get; set; }
        [DisplayName("Client login")]
        public string Login { get; set; }
        [DisplayName("Client password")]
        public string Password { get; set; }
    }
}
