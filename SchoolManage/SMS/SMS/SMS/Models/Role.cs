using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace SMS.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleFunctions = new HashSet<RoleFunction>();
        }

        public int RoleId { get; set; }
        public string Description { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<RoleFunction> RoleFunctions { get; set; }
    }
}
