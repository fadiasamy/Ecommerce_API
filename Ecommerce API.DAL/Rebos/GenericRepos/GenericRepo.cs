using Ecommerce_API.DAL.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Rebos.GenericRebos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly SystemContext _context;

        public GenericRepo(SystemContext context)
        {
            this._context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(T entity)
        {

        }
    }
}
