using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Product
    {
        public int IdProd { get; set; }
        public int ProdCount { get; set; }
        public decimal? Price { get; set; }
        public string? ProdDescription { get; set; }
        public int IdCategory { get; set; }
        public bool IsDeleted { get; set; }
    }
}
