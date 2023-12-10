using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
   public interface IServices<T> where T:BaseUser
    {
        public T GetById(string id);
        public Task<ICollection<T>> GetAll(int pageSize,int pageNumber);
      
      public  void Insert(T entity);
        public Task<bool> Delete(string id);
        public void Update(UserDTO entity, string id);
        public int GetCount();

       
    }
}
