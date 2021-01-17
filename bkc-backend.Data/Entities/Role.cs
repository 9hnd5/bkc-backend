using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class Role: BaseEntity
    {
        public string Name { get; set; }
        public RoleUser RoleUser { get; set; }
    }
}
