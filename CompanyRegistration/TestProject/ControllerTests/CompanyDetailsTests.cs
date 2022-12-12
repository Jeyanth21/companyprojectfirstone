using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyRegistration.Controllers;
using CompanyRegistration.Manager;
using NUnit.Framework;
using Moq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using CompanyRegistration.Data;

namespace TestProject.ControllerTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CompanyDetailsTests
    {
        public Mock<ICdetail> CdetailMock;
        List<CompanyDetails> companydetailsMock;
        [SetUp]
        public void Setup()
        {
            CdetailMock = new Mock<ICdetail>();
            companydetailsMock = new List<CompanyDetails>();
            companydetailsMock.Add(new CompanyDetails() { Id = 99, CompanyName = "bingo", CEO = "april", Turnover = 1223334444, Stock_Exchange = "ABC", Website = "bingo.com" });
        }



        [Test, Category("Company_DetailsController")]
        public void Get_Success()
        {
            //#region MelReportsManager mock setup
            //List<string> summeryReport = new List<string>();
            //summeryReport.Add("AS");
            //#endregion
            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();

            //CompanydetailsManagerMock.Setup(x => x.getall()).ReturnsAsync().Verifiable();
            CompanydetailsManagerMock.Setup(x => x.getall()).Verifiable();
            var CompanydetailsManager = new Company_DetailsController(CompanydetailsManagerMock.Object, Configuration.Object);

            var result = CompanydetailsManager.Get();
            var content = result as OkObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(200, content.StatusCode);
        }

        [Test, Category("Company_DetailsController")]

        public void getbyId_success()
        {
            var CompanydetailsManagerMock = new Mock<ICdetail>();
            var Configuration = new Mock<ILogger<Company_DetailsController>>();
        }


    }


}
        
    

