using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using DomainLayer.DTO;
using DomainLayer.Models;
using ServicesLayer.Services;
using System.Security.Claims;

namespace vezzeta.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
       
        SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountService _accountService;
     

        public AccountController([FromServices] IAccountService accountService ,  SignInManager<ApplicationUser> signInManager)
        {
         _accountService = accountService;
        _signInManager = signInManager;
           }
        [HttpPost]
        [Route("Register")]
       
        public async Task<IActionResult> register(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                   ApplicationUser NewUser =await _accountService.createPatientAsync(userDTO);
                   if(NewUser!=null)
                { await _signInManager.SignInAsync(NewUser, false); 
                    return Ok("sign up successfully");
                }
                ModelState.AddModelError("", "can't create user");

  
            }
            return BadRequest(ModelState);
        }
        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
       
        public async Task<IActionResult> LoginAsync(LoginDTO loginUser)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser applicationUser = await _accountService.loginAsync(loginUser);
                if (applicationUser != null) {
                    IList<Claim> Claims =await _accountService.GetClaims(applicationUser);
                   await _signInManager.SignInWithClaimsAsync(applicationUser,loginUser.RememberMe,Claims);
                        return Ok("Login Successfully");
                    }
                }
                ModelState.AddModelError("", "invalid userName or password");
                 return Unauthorized(ModelState);
            
        }
    
        [Route("signOut")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return Ok("LogOutSuccessfully");
        }
    }
}
//if (userDTO.Image.Length > 0)
//{
//    using (var memoryStream = new MemoryStream())
//    {
//        await userDTO.Image.CopyToAsync(memoryStream);

//        // Upload the file if less than 2 MB  
//        if (memoryStream.Length < 2097152)
//        {
//            NewUser.ImageData = memoryStream.ToArray();
//        }
//        else
//        {
//            ModelState.AddModelError("File", "The file is too large.");
//        }
//    }
//}
