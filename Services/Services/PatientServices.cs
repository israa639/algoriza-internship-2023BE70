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
    public class PatientServices : IServices<Patient>
    {
        private readonly IRepository<Patient> _Repository;
        public PatientServices(IRepository<Patient> Repository)
        {
            _Repository = Repository;
        }
        public Task<bool> Delete(string id)
        {
           return _Repository.delete(id);
        }

        public Task<ICollection<Patient>> GetAll(int pageSize, int pageNumber)
        {
            return _Repository.getAll( pageSize, pageNumber);
        }

        public Patient GetById(string id)
        {
          return  _Repository.getById(id);
        }

        public int GetCount()
        {
            return _Repository.getCount();
        }

        public void Insert(Patient entity)
        {
            _Repository.insert(entity);
        }

        public void Update(UserDTO entity,string id)
        {
           // _Repository.update(entity);
        }

       
    }
}
