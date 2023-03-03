using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Category
    {
        public int IdCategory { get; set; }
        public string? NameCategory { get; set; }
        public int IdSpecification { get; set; }
        public bool IsDeleted { get; set; }
    }
}
