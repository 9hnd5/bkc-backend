﻿using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace bkc_backend.Services
{
    public interface IUserRoleServices
    {
        public RoleUser GetUserRoleByUserId(int userId);
    }
    public class UserRoleServices : BaseServices<RoleUser>, IUserRoleServices
    {
        public UserRoleServices(BkcDbContext context): base(context)
        {

        }
        public RoleUser GetUserRoleByUserId(int userId)
        {
            var result = (from usr in _context.RoleUsers where usr.EmployeeId == userId select usr).FirstOrDefault();
            return result;
        }
    }
}
