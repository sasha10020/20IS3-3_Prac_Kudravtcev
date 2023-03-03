using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string UserLogin { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public DateTime RegDate { get; set; }
        public bool IsDeleted { get; set; }
        public int IdRole { get; set; }
    }
}
