using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace bkc_backend.Data
{
    public class BookingCarDbContextFactory : IDesignTimeDbContextFactory<BookingCarDbContext>
    {
        public BookingCarDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookingCarDbContext>();
            //optionsBuilder.UseSqlServer(_configuration["ConnectionString"]);
            //optionsBuilder.UseSqlServer("Server=.; Database=HRAD; Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=192.168.170.82; Database=HRAD; User id=sa; password=gf40@2018");
            return new BookingCarDbContext(optionsBuilder.Options);
        }
    }
}
