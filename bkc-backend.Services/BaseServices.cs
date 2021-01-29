using bkc_backend.Data;
using bkc_backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface IBaseServices<T> where T : BaseEntity
    {
        public void Add(T entity);
        public void AddRange(List<T> entities);
        public void Update(T entity);
        public void Remove(T entity);
        public void RemoveRange(List<T> entities);
        public List<T> GetAll();
        public T GetById(int id);
    }
    public class BaseServices<T> : IBaseServices<T> where T : BaseEntity
    {
        public BookingCarDbContext _context;
        public DbSet<T> _entity;
        public BaseServices(BookingCarDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _entity.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(List<T> entities)
        {
            _entity.AddRange(entities);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(int id)
        {
            return _entity.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(T entity)
        {
            _entity.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(List<T> entities)
        {
            _entity.RemoveRange(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
            _context.SaveChanges();
        }
    }
}
