using DomainLayer.DTO;
using DomainLayer.Models;
using RepositoryLayer.IRepository;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public class DoctorServices : IDoctorServices
    {
        private readonly IDoctorRepository _Repository;
        public DoctorServices(IDoctorRepository Repository)
        {
            _Repository = Repository;
        }
        public Task<bool> Delete(string id)
        {
            return _Repository.delete(id);
        }

        public Task<List<DoctorWithSpecializeDTO>> GetAll(int pageSize, int pageNumber)
        {
            return _Repository.getAll(pageSize,pageNumber);
        }

        public Doctor GetById(string id)
        {
            return this._Repository.getById(id);
        }

        public Task<int> getCount()
        {
            return this._Repository.GetCount();
        }

        public async Task<bool> update(DoctorDTO doctor, string id)
        {
            var oldDoctor = _Repository.getById(id);
            oldDoctor.specializationId = doctor.specializationId;
            oldDoctor.applicationUser.PhoneNumber = doctor.phoneNumber;
            oldDoctor.applicationUser.Email = doctor.Email;
            oldDoctor.applicationUser.gender = doctor.gender;
            oldDoctor.applicationUser.FirstName = doctor.FirstName;
            oldDoctor.applicationUser.LastName = doctor.LastName;
            oldDoctor.applicationUser.UserName = doctor.UserName;


          return await _Repository.update(oldDoctor, id);
        }
    }
}
