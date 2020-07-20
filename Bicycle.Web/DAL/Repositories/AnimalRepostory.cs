using Bicycle.Web.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle.Web.DAL.Repositories
{
    public class AnimalRepostory : IRepository<Animal>
    {
        ApplicationDbContext db;
        public AnimalRepostory()
        {
            db = new ApplicationDbContext();
        }
        public IEnumerable<Animal> GetAll()
        {
            return db.Animals.ToList();
        }

        public Animal Get(int id)
        {
            return db.Animals.Find(id);
        }

        public void Create(Animal item)
        {
            db.Animals.Add(item);
        }

        public void Update(Animal item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Animal user = db.Animals.Find(id);
            if (user != null)
                db.Animals.Remove(user);
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
