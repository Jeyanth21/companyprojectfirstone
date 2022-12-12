using CompanyRegistration.Data;
using CompanyRegistration.Manager;
using CompanyRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Company_DetailsController : ControllerBase
    { 
 


        private readonly ICdetail _cdetail;
        private readonly ILogger<Company_DetailsController> logger;

        public Company_DetailsController(ICdetail cdetail,ILogger<Company_DetailsController> logger)
    {
        _cdetail = cdetail;
            this.logger = logger;
        }

[HttpPost("CreateCompanyDetails")]

       
        public IActionResult Create([FromBody] CompanyDetailsRequest request)
        {
            logger.LogInformation("Creating company Details");
       

        try
        {
            var p = _cdetail.Create(request);
            return Ok(p);
        }
        catch (Exception ex)
        {

            return StatusCode(500, "An error has occured");
        }



    }

[HttpGet("GetCompanyDetails")]

        public IActionResult Get()
        {

            logger.LogInformation("get company Details method is executed");

            var p = _cdetail.getall();
            return Ok(p);
           
        }



        
[HttpGet("GetCompanyDetails/{UserID}")]
        public IActionResult Get([FromRoute] int UserID)
        {
            try
            {

                logger.LogInformation("getbyID method is executed");
                var p = _cdetail.getbyId(UserID);

                return Ok(p);

            }
            catch(Exception ex)
            {
                logger.LogDebug($"there is no {UserID} present with this Id");

                return StatusCode(500, "An error has occured");
            }

            
        }



[HttpPut("UpdateCompanyDetails")]

        public IActionResult Update([FromBody] CompanyDetailsRequest request)
        {
            logger.LogDebug($"request is updated {request} ");
            var p = _cdetail.Update(request);
            return Ok(p);
             
        }

[HttpDelete("DeleteCompanyDetails/{UserID}")]

        public IActionResult Delete([FromRoute] int UserID)
        {
            logger.LogDebug($" {UserID} is deleted");
            var p = _cdetail.deletebyId(UserID);
            return Ok(p);
           
            }

        }

}
