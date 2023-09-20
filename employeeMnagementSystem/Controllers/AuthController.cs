using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.dto;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly Itokenrepository tokenrepository;

        public AuthController(UserManager<IdentityUser> userManager,Itokenrepository tokenrepository) { 
        
        this.UserManager = userManager;
        this.tokenrepository = tokenrepository;
        }

        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterrequestDTO registerrequestDTO)
        {
            var identityUser = new IdentityUser()
            {
                UserName = registerrequestDTO.Username,
                Email = registerrequestDTO.Username
            };
           var identityResult = await UserManager.CreateAsync(identityUser ,registerrequestDTO.Password);

            if (identityResult.Succeeded)
            {
                if (registerrequestDTO.Roles != null && registerrequestDTO.Roles.Any() )
                {
                    await UserManager.AddToRolesAsync(identityUser, registerrequestDTO.Roles);
                    if (identityResult.Succeeded )
                    {
                        return Ok("User was registred! please login.");
                    }
                }
              
            }               
            return BadRequest("somthing went wrong");
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> login([FromBody] loginrequestdto loginrequestdto)
        {
            var user = await UserManager.FindByEmailAsync(loginrequestdto.Username);

            if (user != null)
            {
               var checkpaswordResult = await UserManager.CheckPasswordAsync(user, loginrequestdto.Password);

                if(checkpaswordResult)
                {
                    var roles = await UserManager.GetRolesAsync(user);
                   if (roles != null )
                    {
                        var jwttoken = tokenrepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwttoken,
                        };

                        return Ok(response);
                    }
                 
                }
                     
            }
            return BadRequest("username or password not correct");
        }
    }
}
