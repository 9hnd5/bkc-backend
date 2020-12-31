using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace bkc_backend.Services
{
    public interface IUserRoleServices
    {
        public UserRole GetUserRoleByUserId(string userId);
    }
    public class UserRoleServices : BaseServices<UserRole>, IUserRoleServices
    {
        public UserRoleServices(BkcDbContext context): base(context)
        {

        }
        public UserRole GetUserRoleByUserId(string userId)
        {
            var result = (from usr in _context.UserRoles where usr.EmployeeId == userId select usr).FirstOrDefault();
            return result;
        }
    }
}
