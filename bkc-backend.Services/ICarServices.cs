using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface ICarServices: IBaseServices<Car>
    {
        public List<Car> GetCarsByBuId(string buId);
        public List<Car> GetCarByDriverId(int driverId);
    }
    public class CarServices: BaseServices<Car>, ICarServices
    {
        public CarServices(BookingCarDbContext context): base(context)
        {

        }

        public List<Car> GetCarByDriverId(int driverId)
        {
            return null;
        }

        public List<Car> GetCarsByBuId(string buId)
        {
            return _context.Cars.Where(x => x.BuId == buId).ToList();
        }
    }
}
