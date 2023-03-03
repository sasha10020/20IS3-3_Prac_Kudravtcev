using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class OrdersStatus
    {
        public int IdStatus { get; set; }
        public string OrdersStatus1 { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
