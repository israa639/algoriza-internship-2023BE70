using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   //[Authorize(Roles = "Admin,admin")]
    public class AdminController : ControllerBase
    {
        private readonly IDoctorServices _DoctorServices;
        private readonly IServices<Patient> _PatientServices;
       
      public  AdminController(IDoctorServices DoctorServices, IServices<Patient> PatientServices)
        {
            _DoctorServices = DoctorServices;
            _PatientServices = PatientServices;
        }
       
        [HttpGet]
        [Route("NumOfDoctors")]
        public async Task<IActionResult> GetNumOfDoctorsAsync()
        {
            int DoctorsNum = await _DoctorServices.getCount();
            return Ok(DoctorsNum);

        }
        [HttpGet]
        [Route("NumOfPatients")]
        public IActionResult GetNumOfPatients()
        {

           int PatientsNum = _PatientServices.GetCount();
           return Ok(PatientsNum);

        }
        [HttpGet]
        [Route("TopSpecializations")]
        public void GetTopSpecializations(int Num)
        {


        }
        [HttpGet]
        [Route("TopDoctors")]
        public void GetTopDoctors(int Num)
        {


        }
       
        [HttpGet]
        [Route("GetDoctorById")]
        public Doctor GetDoctorById(String id)
        {
          return  _DoctorServices.GetById(id);
        }
        [HttpGet]
        [Route("GetAllDoctors")]
        public async Task<ICollection<DoctorWithSpecializeDTO>> GetAllDoctors(int pageSize, int pageNumber)
        {
           return await _DoctorServices.GetAll(pageSize,  pageNumber);
        }
        [HttpPost]
        [Route("AddDoctor")]
        public async Task<IActionResult> AddDoctorAsync(DoctorDTO userDTO, [FromServices] IAccountService accountService)
        {
           var doctor=await accountService.createDoctorAsync(userDTO);

            if (doctor != null)
            {
                
                return Ok("added succesfully");
            }
            return BadRequest("Invalid Data");

        }
        [HttpDelete]
        [Route("DeleteDoctor")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            var result=await _DoctorServices.Delete(id);
            if (result)
                return Ok("deleted successfully");

            return BadRequest("invalid doctor id");
        }

        [HttpPut]
        [Route("UpdateDoctor")]
        public void UpdateDoctor(DoctorDTO user, String id)
        {
            _DoctorServices.update(user, id);
        }

    }

}