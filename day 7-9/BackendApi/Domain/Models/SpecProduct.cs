using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class SpecProduct
    {
        public int IdSpecProduct { get; set; }
        public int IdProd { get; set; }
        public int IdSpecification { get; set; }
        public int SpecValue { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product IdProdNavigation { get; set; } = null!;
        public virtual Specification IdSpecificationNavigation { get; set; } = null!;
    }
}
