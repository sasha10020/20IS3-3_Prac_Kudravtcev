using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int IdUser { get; set; }
        public int IdProd { get; set; }
        public int IdStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProdCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
