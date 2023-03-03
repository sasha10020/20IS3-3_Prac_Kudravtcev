using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class UsersRole
    {
        public int IdRole { get; set; }
        public string NameRole { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
