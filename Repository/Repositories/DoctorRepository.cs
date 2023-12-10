using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        Entities _context;
        private DbSet<Specialization> _specializations;
        private DbSet<Doctor> _Doctors;
        public DoctorRepository(Entities context)
        {
            _context = context;
            _specializations = _context.Set<Specialization>();
            _Doctors = _context.Set<Doctor>();

        }
        public async Task<bool> delete(string id)
        {
            if (id != null)
            {

                var entity = _Doctors.Where(u => u.Id == id).SingleOrDefault();
                if (entity != null)
                {
                    _Doctors.Remove(entity);
                    this.saveChanges();
                    return true;
                }

            }
            return false;
        }


        public Doctor getById(string id) => _Doctors.SingleOrDefault(u => u.Id == id);

        public async Task<List<DoctorWithSpecializeDTO>> getAll(int pageSize, int pageNumber)
        {
            var doctors = _Doctors.ToList();

            var specializations = _specializations.ToList();
            var result = doctors.Join(specializations, doctor => doctor.specializationId, spec => spec.Id,
                (d, s) => new DoctorWithSpecializeDTO()
                {
                    Email = d.applicationUser.Email,
                   phoneNumber = d.applicationUser.PhoneNumber,
                    specializationName = s.ArabicName
                }).Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();





            return result;




        }

        public async Task<bool> update(Doctor entity, string id)
        {
            if (entity != null)
            {
                var oldEntity = _Doctors.SingleOrDefault(u => u.Id == id);
                oldEntity = entity;
                await this.saveChanges();
                return true;
            }
            return false;
        }

    public async Task saveChanges() => this._context.SaveChanges();

        public Task<int> GetCount()
        {
            return this._Doctors.CountAsync();
        }
    }
}
