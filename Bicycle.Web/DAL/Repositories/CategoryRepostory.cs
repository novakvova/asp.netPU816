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
    public class CategoryRepostory : IRepository<Category>
    {
        ApplicationDbContext db;
        public CategoryRepostory()
        {
            db = new ApplicationDbContext();
        }
        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            var query = db.Categories.AsQueryable();
            if(filter!=null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public void Create(Category item)
        {
            db.Categories.Add(item);
        }

        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Category item = db.Categories.Find(id);
            if (item != null)
                db.Categories.Remove(item);
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
