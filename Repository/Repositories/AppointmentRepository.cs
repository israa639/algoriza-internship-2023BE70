using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {


        Entities _context;
        private DbSet<Appointment> _appointments;
        private DbSet<Booking> _Bookings;
        private DbSet<Patient> _Patients;
        public AppointmentRepository(Entities context)
        {
            _context = context;
            _appointments = _context.Set<Appointment>();
            _Bookings = _context.Set<Booking>();
            _Patients = _context.Set<Patient>();

        }
        public async Task insert(Appointment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _appointments.Add(entity);
            await this.saveChanges();
        }
        public async Task<bool> update(Appointment entity, string id)
        {
            if (entity != null)
            {
                var oldEntity = _appointments.SingleOrDefault(u => u.Id == id);
                oldEntity = entity;
                await this.saveChanges();
                return true;
            }
            return false;
        }
        public async Task<List<BookingWithPatientDTO>> getAll(int pageSize, int pageNumber,string doctorId)
        {

            var allAppointments = _appointments.ToList();
            var allBookings = _Bookings.ToList();
            var allPatients = _Patients.ToList();
            
            var pagedEntities =  allAppointments
                          .Where(a => a.doctorId == doctorId).
                          Join(allBookings,
                          appointment => appointment.Id,
                          booking => booking.appointmentId, 
                          (appointment, booking) =>
                          new {day=appointment.day,status=booking.status,time=booking.bookingTime,patientId=booking.patientId})
                          .Join(allPatients,
                          booking=>booking.patientId,
                          patient=>patient.Id,
                          (booking, patient) => new BookingWithPatientDTO{ day = booking.day,
                              status = booking.status, time = booking.time,
                              Email=patient.applicationUser.Email,
                              gender= (Enums.Gender)patient.applicationUser.gender,
                              phone= patient.applicationUser.PhoneNumber }
                          ).Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();









            return pagedEntities;


        }
        public async Task<bool> delete(string id)
        {
            if (id != null)
            {

                var entity = _appointments.Where(u => u.Id == id).SingleOrDefault();
                if (entity != null)
                {
                    _appointments.Remove(entity);
                    this.saveChanges();
                    return true;
                }

            }
            return false;
        }



        public async Task saveChanges() => this._context.SaveChanges();

       

    }
}
