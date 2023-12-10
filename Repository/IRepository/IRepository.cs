using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public interface IRepository<T>where T:BaseEntity
    {
        public  Task insert(T entity);
        public Task<bool> update(T entity,string id);
        public Task<bool> delete(string id);
        public T getById(string id);
        public Task<ICollection<T>> getAll(int pageSize, int pageNumber);
        public ICollection<T> getTopEntitiesByPredicate(int num, Func<T,int> order);

        public int getCount();

         Task saveChanges();
    }
}
