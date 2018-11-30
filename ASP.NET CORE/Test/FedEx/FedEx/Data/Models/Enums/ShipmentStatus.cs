using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FedEx.Data.Models.Enums
{
    public enum ShipmentStatus
    {
        Delivered = 1,
        OnTheWay = 2,
        Blocked = 3,
        Pending = 4
    }
}
