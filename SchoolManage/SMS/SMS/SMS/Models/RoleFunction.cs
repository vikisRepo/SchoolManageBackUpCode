using System;
using System.Collections.Generic;

#nullable disable

namespace SMS.Models
{
    public partial class RoleFunction
    {
        public int RoleFunctionId { get; set; }
        public int RoleId { get; set; }
        public int FunctionId { get; set; }

        public virtual Function Function { get; set; }
        public virtual Role Role { get; set; }
    }
}
