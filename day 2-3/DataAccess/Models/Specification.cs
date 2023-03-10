using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Specification
    {
        public int IdSpecification { get; set; }
        public string? NameSpec { get; set; }
        public int SpecValue { get; set; }
        public bool IsDeleted { get; set; }
    }
}
