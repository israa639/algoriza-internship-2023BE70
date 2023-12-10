using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        Entities _context;
        private DbSet<T> _entities;
        public Repository(Entities context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task<bool> delete(string id)
        {
            if (id != null)
            {

               var entity= _entities.Where(u=>u.Id==id).SingleOrDefault();
                if(entity!=null)
                {
                    _entities.Remove(entity);
                    this.saveChanges();
                    return true;
                }
               
            }
            return false;
        }

        public async Task<ICollection<T>> getAll(int pageSize, int pageNumber)
        {

            var allEntities = _entities.AsQueryable();

            var pagedEntities = await allEntities
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            return pagedEntities;


        }
    

        public T getById(string id) => _entities.SingleOrDefault(u => u.Id == id);


        public ICollection<T> getTopEntitiesByPredicate(int num, Func<T, int> order)
            => _entities.OrderBy(order).Take(num).ToList();


        public async Task insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
           _entities.Add(entity);
            await this.saveChanges();
        }
        public async Task<bool> update(T entity, string id)
        {
            if (entity != null)
            {
              var oldEntity= _entities.SingleOrDefault(u => u.Id == id);
                oldEntity = entity;
               await this.saveChanges();
                return true;
            }
            return false;
        }
        public async Task saveChanges() => this._context.SaveChanges();

        public int getCount()=> this._entities.Count();
      
    }
}
