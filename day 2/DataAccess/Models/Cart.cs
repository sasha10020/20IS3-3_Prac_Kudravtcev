using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Cart
    {
        public int IdCart { get; set; }
        public int IdUser { get; set; }
        public int IdProd { get; set; }
        public int ProdCount { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CartDate { get; set; }
    }
}
