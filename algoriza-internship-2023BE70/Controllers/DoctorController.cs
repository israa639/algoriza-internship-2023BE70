using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServicesLayer.Services;

namespace WebApplication3.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        IAppointmentServices _appointmentServices;
       
       public DoctorController( IAppointmentServices appointmentServices, IDoctorServices DoctorServices)
        {
            _appointmentServices = appointmentServices;
          
        }
        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetAll(Enums.Day Date,int PageSize,int PageNumber)
        {
            var doctorId = HttpContext.User.FindFirst("DoctorId")?.Value??"00";
            if (doctorId != "00")
            {
             var result= _appointmentServices.GetAll(PageSize, PageNumber, doctorId);

                if(result!=null)
                    return Ok( result.Result);
              

            }
            return BadRequest("no data found");
        }
        
        [HttpPost]
        [Route("AddAppointment")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Add(AppointmentDto appoinmentDTO)
        {
            if (ModelState.ErrorCount == 0)
            {
                var doctorId = HttpContext.User.FindFirst("DoctorId")?.Value??"00";
                if (doctorId != "00")
                    await _appointmentServices.AddAsync(appoinmentDTO, doctorId);
                return Ok("appointments added successfully");
            }
            return BadRequest("invalid appointments");
        }
        [HttpPut]
        [Route("ConfirmCheckUp")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> ConfirmCheckUp(string BookingId)
        {
          var result=await  _appointmentServices.ConfirmCheckUp(BookingId);
            if(result)
                return Ok("booking confirmed Successfully");

            return BadRequest("failed to confirm booking");
        }
        [HttpPut]
        [Route("Update")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Update(string BookingId, BookingTimeDTO bookingTime)
        {
            if (ModelState.ErrorCount == 0)
            {
                var result = await _appointmentServices.update(BookingId, bookingTime);
                if(result)
                return Ok("Booking Time has been changed Successfully");
            }
            return BadRequest("Failed to update, this Booking has Been already booked or completed");
        }
        [HttpDelete]
        [Route("Delete")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Delete(string BookingId)
        {
            var result = await _appointmentServices.delete(BookingId);
            if(result)
                return Ok("Booking Time has been deleted Successfully");

            return BadRequest("Failed to delete , this Booking has Been already booked or completed");

        }


    }
}
