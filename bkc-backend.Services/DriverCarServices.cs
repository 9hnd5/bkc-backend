using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bkc_backend.Data;
using bkc_backend.Data.Entities;

namespace bkc_backend.Services
{
    public interface IDriverCarServices
    {
        public object getByBuId(string buId);
    }
    public class DriverCarServices: IDriverCarServices
    {
        BkcDbContext _context;
        public DriverCarServices(BkcDbContext context)
        {
            _context = context;
        }

        public object getByBuId(string buId)
        {
            var driverCars = (from d in _context.Drivers
                          join c in _context.Cars
                          on d.Id equals c.DriverId
                          select new DriverCar { 
                            DriverId=d.Id,
                            DriverName=d.Name,
                            DriverPhone=d.Phone,
                            DriverEmail=d.Email,

                            CarId = c.Id,
                            CarNumber = c.Number,
                            CarTotalSeat = c.TotalSeat,
                            CarAvailableSeat = c.AvailableSeat,
                            CarStatus = c.Status,
                            CarBookingDate = c.BookingDate,
                            CarBuId = c.BuId,
                            CarBuName = c.BuName
                          }).ToList();
            return driverCars.Where(dc => dc.CarBuId == buId).ToList();
        }
    }
}
