using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjectTeamFour.Reposities
{
    public class BaseReposity<T> where T:class
    {
        public DbContext _context;
        public BaseReposity(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException();
            }
            this._context = context;
        }
        public void Create(T value)
        {
            _context.Entry(value).State = EntityState.Added;
            _context.SaveChanges();
        }
        public void Update(T value)
        {
            _context.Entry(value).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(T value)
        {
            _context.Entry(value).State = EntityState.Deleted;
            _context.SaveChanges();
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
    }
}