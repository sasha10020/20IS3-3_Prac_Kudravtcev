using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class OrdersStatus
    {
        public OrdersStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int IdStatus { get; set; }
        public string OrdersStatus1 { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
