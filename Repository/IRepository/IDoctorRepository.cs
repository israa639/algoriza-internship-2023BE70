using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IDoctorRepository
    {

        public Task<List<DoctorWithSpecializeDTO>> getAll(int pageSize, int pageNumber);
        public Doctor getById(string id);
        public Task<bool> update(Doctor entity, string id);
        public Task<bool> delete(string id);

        public Task<int> GetCount();



    }
}
