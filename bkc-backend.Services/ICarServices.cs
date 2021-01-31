using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface ICarServices : IBaseServices<Car>
    {
        public List<Car> GetCarsByBuId(string buId);
        public List<Car> GetAllCarByBuId(string buId);
        public List<Car> GetCarByDriverId(int driverId);
        public void UpdateCar(Car car);
    }
    public class CarServices : BaseServices<Car>, ICarServices
    {
        public CarServices(BookingCarDbContext context) : base(context)
        {

        }

        public List<Car> GetAllCarByBuId(string buId)
        {
            return _context.Cars.Where(x => x.BuId == buId).ToList();
        }

        public List<Car> GetCarByDriverId(int driverId)
        {
            return null;
        }

        public List<Car> GetCarsByBuId(string buId)
        {
            var cars = (from car in _context.Cars
                        where !_context.Drivers.Where(x => x.CarId != -1).Select(x => x.CarId).Contains(car.Id)
                        select car).ToList();
            return cars;
        }

        public void UpdateCar(Car car)
        {
            var carEntity = GetById(car.Id);
            carEntity.BuId = car.BuId;
            carEntity.BuName = car.BuName;
            carEntity.CurrentLocation = car.CurrentLocation;
            carEntity.Number = car.Number;
            carEntity.TotalSeat = car.TotalSeat;
            _context.SaveChanges();
        }
    }
}
