using CompanyRegistration.Data;
using CompanyRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace CompanyRegistration.Manager
{
    public class Register : IRegister
    {

        private CompanyDbContext _dbcontext;

        public Register(CompanyDbContext dbcontext)
        {
            _dbcontext = dbcontext;


        }
        public List<UserDetails>  Create(UserDetailsRequest request)
        {
            UserDetails userDetails = new UserDetails();
            {
                userDetails.Id = request.Id;
                userDetails.UserName = request.UserName;
                userDetails.Email = request.Email;
                userDetails.Password = request.Password;


                _dbcontext.userdetails.Add(userDetails);
                _dbcontext.SaveChanges();
      
                return _dbcontext.userdetails.ToList();

            }
        }

        public UserDetails getlogin(string Email, string Password)
        {


            
            var userdetails = _dbcontext.userdetails.Where(x => x.Email == Email && x.Password==Password).SingleOrDefault();

           

           

            return userdetails;

        }

        


    }
}
