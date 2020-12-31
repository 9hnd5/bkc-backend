using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bkc_backend.Data;
using bkc_backend.Data.Entities;

namespace bkc_backend.Services
{
    public interface ICarServices: IBaseServices<Car>
    {

    }
    public class CarServices: BaseServices<Car>, ICarServices
    {
        public CarServices(BkcDbContext context): base(context)
        {

        }
    }
}
