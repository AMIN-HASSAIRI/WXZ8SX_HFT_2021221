using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Data;

namespace WXZ8SX_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MusicDbContext MusicDbContext;

        protected Repository(MusicDbContext musicDbContext)
        {
            MusicDbContext = musicDbContext;
        }

        public void Add(T entity)
        {
            MusicDbContext.Set<T>().Add(entity);
            MusicDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            MusicDbContext.Set<T>().Remove(entity);
            MusicDbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return MusicDbContext.Set<T>();
        }

        public abstract T GetOne(int id);

        public void Update(T entity)
        {
            MusicDbContext.Set<T>().Attach(entity);
            MusicDbContext.SaveChanges();
        }

    }
}
