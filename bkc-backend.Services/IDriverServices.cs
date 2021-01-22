using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{

    public interface IDriverServices: IBaseServices<Driver>
    {
        public List<Driver> GetDriverByBuId(string buId);
    }
    public class DriverServices: BaseServices<Driver>, IDriverServices
    {
        public ICarServices _carServices;
        public DriverServices(BookingCarDbContext context, ICarServices carServices) : base(context)
        {
            _carServices = carServices;
        }

        public List<Driver> GetDriverByBuId(string buId)
        {
            var drivers = _context.Drivers.Where(x => x.EmployeeBuId == buId).ToList();
            foreach(var driver in drivers)
            {
                var car = _carServices.GetById(driver.CarId);
                driver.Car = car;
            }
            return drivers;
        }
    }
}
