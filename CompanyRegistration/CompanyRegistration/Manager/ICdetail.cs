using CompanyRegistration.Data;
using CompanyRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRegistration.Manager
{
    public interface ICdetail
    {
        List<CompanyDetails> Create(CompanyDetailsRequest request);

        List<CompanyDetails> Update(CompanyDetailsRequest request);

        CompanyDetails getbyId(int UserID);

        List<CompanyDetails> getall();


        List<CompanyDetails> deletebyId(int UserID);


    }
}
