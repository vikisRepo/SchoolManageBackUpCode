using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace SMS.Models
{
    public partial class Function
    {
        public Function()
        {
            RoleFunctions = new HashSet<RoleFunction>();
        }

        public int FunctionId { get; set; }
        public string Decription { get; set; }
        public string DisplayValue { get; set; }
        public string DisplayOrder { get; set; }
        public int? ParentFunctionId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<RoleFunction> RoleFunctions { get; set; }
    }
}
