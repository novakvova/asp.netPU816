using Bicycle.Web.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle.Web.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        ApplicationDbContext db;
        public ProductRepository()
        {
            db = new ApplicationDbContext();
        }
        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var query = db.Products.AsQueryable();
            if(filter!=null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product item = db.Products.Find(id);
            if (item != null)
                db.Products.Remove(item);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
