using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Specification
    {
        public Specification()
        {
            Categories = new HashSet<Category>();
            SpecProducts = new HashSet<SpecProduct>();
        }

        public int IdSpecification { get; set; }
        public string? NameSpec { get; set; }
        public int SpecValue { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<SpecProduct> SpecProducts { get; set; }
    }
}
