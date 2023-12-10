using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace vezeeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles="Patient")]
    public class PatientController : ControllerBase
    {
    }
}
