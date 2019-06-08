using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.UserR
{
    public class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public  ICollection<UserRole> UserRoles { get; set; }
    }
}
