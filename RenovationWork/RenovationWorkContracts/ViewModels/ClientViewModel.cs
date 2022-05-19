using RenovationWorkContracts.Attributes;
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
        [Column(title: "Client fullname", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Fullname { get; set; }
        [Column(title: "Client login", width: 150)]
        public string Login { get; set; }
        [Column(title: "Client password", width: 100)]
        public string Password { get; set; }
    }
}
