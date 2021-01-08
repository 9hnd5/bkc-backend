using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace bkc_backend.Data
{
    public class BkcDbContextFactory : IDesignTimeDbContextFactory<BkcDbContext>
    {
        public BkcDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BkcDbContext>();
            //optionsBuilder.UseSqlServer(_configuration["ConnectionString"]);
            //optionsBuilder.UseSqlServer("Server=.; Database=HRAD; Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=192.168.170.82; Database=HRAD; User id=sa; password=gf40@2018");
            return new BkcDbContext(optionsBuilder.Options);
        }
    }
}
