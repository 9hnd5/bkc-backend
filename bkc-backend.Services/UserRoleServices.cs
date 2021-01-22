using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace bkc_backend.Services
{
    public interface IUserRoleServices : IBaseServices<RoleUser>
    {
        public RoleUser GetUserRoleByUserId(string userId);
    }
    public class UserRoleServices : BaseServices<RoleUser>, IUserRoleServices
    {
        public UserRoleServices(BookingCarDbContext context) : base(context)
        {

        }
        public RoleUser GetUserRoleByUserId(string employeeId)
        {


            var result = (from roleUser in _context.RoleUsers
                          where roleUser.EmployeeId == employeeId
                          select roleUser).FirstOrDefault();
            return result;


        }
    }
}
