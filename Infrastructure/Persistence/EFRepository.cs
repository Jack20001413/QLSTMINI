using Domain.Entities;
using Domain.Entities.Common;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System;
namespace Infrastructure.Persistence
{
    public class EFRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {   
        protected readonly SupermarketDbContext _db;

        public EFRepository(SupermarketDbContext db)
        {
            _db = db;
        }

        public void Add(T entity)
        {
            //_db.Set<T>().Add(entity);
            //_db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _db.Add<T>(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public T GetBy(int id)
        {
            T ent = _db.Set<T>().Find(id);
            _db.Entry(ent).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return ent;
            // return _db.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
        }
    }
}