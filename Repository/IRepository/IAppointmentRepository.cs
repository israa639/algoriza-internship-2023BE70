using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public interface IAppointmentRepository
    {

        public Task<List<BookingWithPatientDTO>> getAll(int pageSize, int pageNumber, string doctorId);
        public Task insert(Appointment entity);
        public Task<bool> update(Appointment entity, string id);
        public Task<bool> delete(string id);

    }
}