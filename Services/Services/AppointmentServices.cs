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
    public class AppointmentServices : IAppointmentServices
    {
        private readonly IAppointmentRepository _appointmentRepository;

       
        private readonly IRepository<Booking> _BookingRepository;

        public AppointmentServices(IAppointmentRepository appointmentRepository, IRepository<Booking> BookingRepository)
        {
            _appointmentRepository = appointmentRepository;
            _BookingRepository = BookingRepository;
        }
        public async Task<ICollection<BookingWithPatientDTO>> GetAll(int pageSize, int pageNumber, string doctorId)
        {


            return await _appointmentRepository.getAll(pageSize, pageNumber, doctorId);
        }
        private async Task AddAppointmentWithBookings(AppointmentDto appointmentDTO, string _doctorId)
        {
         
            foreach (var appointment in appointmentDTO.appointments)
            {
               // if(appointment.Key!=)
                Appointment _appointment = new Appointment()
                {
                    Id = Guid.NewGuid().ToString(),
                    doctorId = _doctorId,
                    price = appointmentDTO.price,
                    day = appointment.Key,

                };

                await _appointmentRepository.insert(_appointment);
                foreach (var time in appointment.Value)
                {
                    Booking booking = new Booking()
                    {
                        Id = Guid.NewGuid().ToString(),
                        appointmentId = _appointment.Id,
                        status = Enums.BookingStatus.available,
                        bookingTime = time.time
                    };
                   await _BookingRepository.insert(booking);
                }
            }
        }
        public async Task AddAsync(AppointmentDto appointmentDTO,string _doctorId)
        {
          await AddAppointmentWithBookings(appointmentDTO, _doctorId);
        }

        public async Task<bool> ConfirmCheckUp(string BookingId)
        {
          var booking= _BookingRepository.getById(BookingId);
            booking.status = Enums.BookingStatus.completed;

         bool  result=  await _BookingRepository.update(booking, BookingId);

            return result;
        }

        public async Task<bool> update(string BookingId, BookingTimeDTO bookingTime)
        {
            var booking = _BookingRepository.getById(BookingId);
            if (booking.status == Enums.BookingStatus.available)
            {
                booking.bookingTime = bookingTime.time;
                bool result = await _BookingRepository.update(booking, BookingId);
                return result;
            }
            return false;
        }

        public async Task<bool> delete(string BookingId)
        {
            var booking = _BookingRepository.getById(BookingId);
            if (booking.status == Enums.BookingStatus.available)
            { 
                bool result = await _BookingRepository.delete( BookingId);
                return result;
            }
            return false;
        }
    }
}
