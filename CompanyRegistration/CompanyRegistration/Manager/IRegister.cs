using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyRegistration.Data;
using CompanyRegistration.Models;

namespace CompanyRegistration.Manager
{
   public interface IRegister
    {
      List<UserDetails> Create(UserDetailsRequest request);

        UserDetails getlogin(string Email, string Password);
    }
}
