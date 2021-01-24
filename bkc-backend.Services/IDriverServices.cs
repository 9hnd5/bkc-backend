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
        public void UpdateDriver(Driver driver);
        public List<Driver> GetDrivers();
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

        public List<Driver> GetDrivers()
        {
            var drivers = GetAll();
            foreach(var driver in drivers)
            {
                var car = _carServices.GetById(driver.CarId);
                driver.Car = car;
            }
            return drivers;
        }

        public void UpdateDriver(Driver driver)
        {
            var driverEntity = GetById(driver.Id);
            if(driverEntity == null)
            {
                return;
            }
            driverEntity.EmployeeId = driver.EmployeeId;
            driverEntity.EmployeeName = driver.EmployeeName;
            driverEntity.EmployeePhone = driver.EmployeePhone;
            driverEntity.EmployeeBuId = driver.EmployeeBuId;
            driverEntity.EmployeeBuName = driver.EmployeeBuName;
            driverEntity.CarId = driver.CarId;
            _context.SaveChanges();
        }
    }
}
