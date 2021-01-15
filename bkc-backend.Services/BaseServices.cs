using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bkc_backend.Services
{
    public interface IBaseServices<T> where T: BaseEntity
    {
        public void insert(T obj);
        public void update(T obj);
        public void delete(T obj);
        public void deleteById(string id);
        public List<T> getAll();
        public T getById(object id);
    }
    public class BaseServices<T> : IBaseServices<T> where T : BaseEntity
    {
        public readonly BookingCarDbContext _context;
        public BaseServices(BookingCarDbContext context)
        {
            _context = context;
        }
        public void delete(T obj)
        {
            _context.Set<T>().Remove(obj);
        }

        public void deleteById(string id)
        {
            T element = (from e in _context.Set<T>()
             where e.Id == id
             select e).FirstOrDefault();
            _context.Set<T>().Remove(element);
        }

        public List<T> getAll()
        {
            return _context.Set<T>().ToList();
        }

        public T getById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public void insert(T obj)
        {
            _context.Set<T>().Add(obj);
        }

        public void update(T obj)
        {
            if (obj == null) throw new ArgumentNullException("entity");
            throw new NotImplementedException();
        }
    }
}
