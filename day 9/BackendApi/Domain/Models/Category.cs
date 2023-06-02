using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int IdCategory { get; set; }
        public string? NameCategory { get; set; }
        public int IdSpecification { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Specification IdSpecificationNavigation { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
