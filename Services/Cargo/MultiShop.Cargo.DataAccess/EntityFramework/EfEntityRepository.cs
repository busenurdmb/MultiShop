using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Concrete;
using MultiShop.Cargo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccess.EntityFramework
{
    public class EfEntityRepository<T> : IEntityRepository<T>
        where T : class, IEntity, new()
        
    {
        protected CargoContext _context;

        public EfEntityRepository(CargoContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var values = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(values);
            _context.SaveChanges();
        }
        public List<T> GetAll()
        {
            var values = _context.Set<T>().ToList();
            return values;
        }
        public T GetById(int id)
        {
            var value = _context.Set<T>().Find(id);
            return value;
        }
        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }

}
