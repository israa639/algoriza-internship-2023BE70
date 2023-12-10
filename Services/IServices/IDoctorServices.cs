using DomainLayer.DTO;
using DomainLayer.Models;

namespace ServicesLayer.Services
{
    public interface IDoctorServices
    {
        public Doctor GetById(String id);
       
        public Task<List<DoctorWithSpecializeDTO>> GetAll(int pageSize, int pageNumber);
        public Task<bool> update(DoctorDTO doctor, string id);
        public Task<bool> Delete( string id);
        public Task<int> getCount();



    }
}