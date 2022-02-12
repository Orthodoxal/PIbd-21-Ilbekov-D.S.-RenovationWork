using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.Enums
{
    /// <summary>
    /// Статус заказа
    /// </summary>
    public enum OrderStatus
    {
        Accepted = 0,
        Executing = 1,
        Ready = 2,
        Issued = 3
    }
}
