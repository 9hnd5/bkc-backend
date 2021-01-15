using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace bkc_backend.Services
{
    public interface IRoleServices: IBaseServices<Role>
    {
    }
    public class RoleServices : BaseServices<Role>, IRoleServices
    {
        public RoleServices(BookingCarDbContext context):base(context)
        {

        }
    }
}
