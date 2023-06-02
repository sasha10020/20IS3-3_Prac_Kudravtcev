using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class UsersRole
    {
        public UsersRole()
        {
            Users = new HashSet<User>();
        }

        public int IdRole { get; set; }
        public string NameRole { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
