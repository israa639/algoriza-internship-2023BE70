using DomainLayer.DTO;
using DomainLayer.Models;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public class UserServices<T>:IServices<T>where T:BaseUser
    {
        private readonly IRepository<T> _Repository;
        public UserServices(IRepository<T> Repository)
        {
            _Repository = Repository;
        }
        public Task<bool> Delete(string id)
        {
           return _Repository.delete(id);
        }

        public Task<ICollection<T>> GetAll(int pageSize, int pageNumber)
        {
            return _Repository.getAll(pageSize,pageNumber);
        }

        public T GetById(string id)
        {
            return _Repository.getById(id);
        }
        public int GetCount()
        {
            return _Repository.getCount();
        }
        public void Insert(T entity)
        {
            _Repository.insert(entity);
        }

        public void Update(UserDTO entity,string id)
        {

          // _Repository.update(entity,id);
        }
    }
}
