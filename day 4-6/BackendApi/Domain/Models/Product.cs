using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            SpecProducts = new HashSet<SpecProduct>();
        }

        public int IdProd { get; set; }
        public int ProdCount { get; set; }
        public decimal? Price { get; set; }
        public string? ProdDescription { get; set; }
        public int IdCategory { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category IdCategoryNavigation { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SpecProduct> SpecProducts { get; set; }
    }
}
