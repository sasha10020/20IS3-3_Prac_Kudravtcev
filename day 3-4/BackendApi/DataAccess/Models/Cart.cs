using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Cart
    {
        public int IdCart { get; set; }
        public int IdUser { get; set; }
        public int IdProd { get; set; }
        public int ProdCount { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CartDate { get; set; }

        public virtual Product IdProdNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
