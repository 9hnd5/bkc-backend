using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{

    public interface IDriverServices : IBaseServices<Driver>
    {
        public List<Driver> GetDriversWasBooked(string buId, bool isFinish);
        public void UpdateDriver(Driver driver);
        public List<Driver> GetDriversByBuId(string buId);
        public Driver GetDriverByCarId(int carId);
    }
    public class DriverServices : BaseServices<Driver>, IDriverServices
    {
        public ICarServices _carServices;
        public DriverServices(BookingCarDbContext context, ICarServices carServices) : base(context)
        {
            _carServices = carServices;
        }

        public List<Driver> GetDriversWasBooked(string buId, bool isFinish)
        {
            var drivers = (from driver in _context.Drivers
                           join ticketCar in _context.TicketCars on driver.CarId equals ticketCar.CarId
                           join ticket in _context.Tickets on ticketCar.TicketId equals ticket.Id
                           where ticket.IsFinish == isFinish && ticket.EmployeeBuId == buId
                           group driver by new
                           {
                               Id = driver.Id,
                               EmployeeId = driver.EmployeeId,
                               EmployeeName = driver.EmployeeName,
                               EmployeePhone = driver.EmployeePhone,
                               EmployeeEmail = driver.EmployeeEmail,
                               EmployeeBuId = driver.EmployeeBuId,
                               EmployeeBuName = driver.EmployeeBuName,
                               CarId = driver.CarId
                           } into g
                           select new Driver
                           {
                               Id = g.Key.Id,
                               EmployeeId=g.Key.EmployeeId,
                               EmployeeName = g.Key.EmployeeName,
                               EmployeePhone = g.Key.EmployeePhone,
                               EmployeeEmail = g.Key.EmployeeEmail,
                               EmployeeBuId = g.Key.EmployeeBuId,
                               EmployeeBuName = g.Key.EmployeeBuName,
                               CarId = g.Key.CarId,
                           }).ToList();
            foreach (var driver in drivers)
            {
                var car = _carServices.GetById(driver.CarId);
                driver.Car = car;
            }
            return drivers;
        }

        public List<Driver> GetDriversByBuId(string buId)
        {
            var drivers = _context.Drivers.Where(x => x.EmployeeBuId == buId).ToList();
            foreach (var driver in drivers)
            {
                var car = _carServices.GetById(driver.CarId);
                driver.Car = car;
            }
            return drivers;
        }

        public void UpdateDriver(Driver driver)
        {
            var driverEntity = GetById(driver.Id);
            if (driverEntity == null)
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

        public Driver GetDriverByCarId(int carId)
        {
            return _context.Drivers.Where(x => x.CarId == carId).FirstOrDefault();
        }
    }
}
