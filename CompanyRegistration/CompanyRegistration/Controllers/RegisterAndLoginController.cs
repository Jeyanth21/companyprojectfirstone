using CompanyRegistration.Data;
using CompanyRegistration.Manager;
using CompanyRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace CompanyRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterAndLoginController : ControllerBase
    {
        //private CompanyDbContext _dbcontext;

        //public RegisterAndLoginController(CompanyDbContext dbcontext)
        //{
        //    _dbcontext = dbcontext;


        //}


        private readonly IRegister _register;
        private readonly ILogger<RegisterAndLoginController> logger;

        public RegisterAndLoginController(IRegister register, ILogger<RegisterAndLoginController> logger)
        {
            _register = register;
            this.logger = logger;
        }


        [HttpPost("CreateUserDetails")]

        public IActionResult Create([FromBody] UserDetailsRequest request)
        {

            try
            {
                logger.LogInformation("Creating User Details");

                var p = _register.Create(request);
                return Ok(p);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error has occured");
            }



            
            
        }


        [HttpPost("login")]

        public IActionResult Get([FromBody] Login user)
        {
            var userdetails = _register.getlogin(user.Email, user.Password);

            if (userdetails != null)
            {

                LoginUserDetails loginUserDetails = new LoginUserDetails();
                loginUserDetails.Email = userdetails.Email;
                loginUserDetails.UserName = userdetails.UserName;
                loginUserDetails.Id = userdetails.Id;

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:61605",
                    audience: "http://localhost:61605",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                loginUserDetails.Token = tokenString;
                //return loginUserDetails;
                return Ok( loginUserDetails );
            }
            else
            {
                return Unauthorized();
            }

            //return Ok(new LoginUserDetails);
        }
    }
}
