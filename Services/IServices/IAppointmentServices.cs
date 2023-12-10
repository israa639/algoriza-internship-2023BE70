using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public interface IAppointmentServices
    {
        public Task<ICollection<BookingWithPatientDTO>> GetAll(int pageSize, int pageNumber, string doctorId);

        public Task<bool> ConfirmCheckUp(string BookingId);
        public Task<bool> update(string BookingId, BookingTimeDTO bookingTime);
       public Task AddAsync(AppointmentDto appointmentDTO,string doctorId);
        public Task<bool> delete(string BookingId);
    }
}
