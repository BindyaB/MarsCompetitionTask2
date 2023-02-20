using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CompTask2.Pages;
using CompTask2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CompTask2.Tests
{
    [TestFixture]
    public class Tests:CommonDriver
    {
        ExtentReports extent = null;
        public ExtentTest test;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\Config\Tests.html");
                extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void LoginActions()
        {

            driver = new ChromeDriver();
            

        }
        [Test, Order(1)]
        public void ACreateShareSkill()
        {
            test = extent.CreateTest("ACreateShareSkill");
            
            ShareSkill shareSkillObj = new ShareSkill();

            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataShareskill.xlsx", "LoginDetails");
            Login loginObj = new Login(ExcelLib.ReadData(1, "url"), ExcelLib.ReadData(1, "username"), ExcelLib.ReadData(1, "password"));


            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataShareskill.xlsx", "ShareSkill");
            
            shareSkillObj.AddShareSkill(ExcelLib.ReadData(1, "title"), ExcelLib.ReadData(1, "description"), ExcelLib.ReadData(1, "category"),
                ExcelLib.ReadData(1, "subcategory"), ExcelLib.ReadData(1, "addtags"), ExcelLib.ReadData(1, "serviceType"), ExcelLib.ReadData(1, "locationType"),
                ExcelLib.ReadData(1, "daysAvaialable"), ExcelLib.ReadData(1, "beginDate"), ExcelLib.ReadData(1, "finishDate"), ExcelLib.ReadData(1, "starttime"),
                ExcelLib.ReadData(1, "endtime"), ExcelLib.ReadData(1, "skilltrade"), ExcelLib.ReadData(1, "skilltags"), ExcelLib.ReadData(1, "charge"),
                ExcelLib.ReadData(1, "active"));
            test.Log(Status.Pass, "New Service Listing added");
                    
        }

        

        [Test, Order(2)]
        public void BViewManageListing()
        {
            test = extent.CreateTest("BViewManageListing");
            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataViewListing.xlsx", "LoginDetails");
            
            Login loginObj = new Login(ExcelLib.ReadData(1, "url"), ExcelLib.ReadData(1, "username"), ExcelLib.ReadData(1, "password"));
            
            ManageListing manageListingObj = new ManageListing();
            manageListingObj.ViewListing();
            test.Log(Status.Pass, "View Service listing passed");

        }

        [Test, Order(3)]
        public void CEditManageListing()
        {
            test = extent.CreateTest("CEditManageListing");
            ManageListing manageListingObj = new ManageListing();

            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataEditShareSkill.xlsx", "LoginDetails");
            Login loginObj = new Login(ExcelLib.ReadData(1, "url"), ExcelLib.ReadData(1, "username"), ExcelLib.ReadData(1, "password"));
            
            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataEditShareSkill.xlsx", "EditShareSkill");
            manageListingObj.EditListing(ExcelLib.ReadData(1, "title"), ExcelLib.ReadData(1, "description"), ExcelLib.ReadData(1, "addtags"), ExcelLib.ReadData(1, "skilltrade"),
                                          ExcelLib.ReadData(1, "skilltags"), ExcelLib.ReadData(1, "charge"));
            test.Log(Status.Pass, "Edited service listing");


        }

        [Test, Order(4)]
        public void DeleteManageListing()
        {
            test = extent.CreateTest("DeleteManageListing");
            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataDeleteListing.xlsx", "LoginDetails");
            Login loginObj = new Login(ExcelLib.ReadData(1, "url"), ExcelLib.ReadData(1, "username"), ExcelLib.ReadData(1, "password"));

            ManageListing manageListingObj = new ManageListing();
            manageListingObj.DeleteListing();
            test.Log(Status.Pass, "Deleted service listing");

            

        }

        [Test, Order(5)]
        public void NullNegativeTest()
        {
            test = extent.CreateTest("NullNegativeTest");
            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataNullValue.xlsx", "LoginDetails");
            Login loginObj = new Login(ExcelLib.ReadData(1, "url"), ExcelLib.ReadData(1, "username"), ExcelLib.ReadData(1, "password"));

            //ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataNullValue.xlsx", "ShareSkill");
            ShareSkill skillObj = new ShareSkill();
            skillObj.NegativeTestNullValues();
            
        }
        [Test, Order(6)]
        public void NegativeValueTest()
        {
            test = extent.CreateTest("NegativeValueTest");
            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataInvalidValue.xlsx", "LoginDetails");
            Login loginObj = new Login(ExcelLib.ReadData(1, "url"), ExcelLib.ReadData(1, "username"), ExcelLib.ReadData(1, "password"));

            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataInvalidValue.xlsx", "ShareSkill");
            ShareSkill skillObj = new ShareSkill();
            skillObj.NegativeTestInvalidValues( ExcelLib.ReadData(1, "title"), ExcelLib.ReadData(1, "description"), ExcelLib.ReadData(1, "category"),
                                                ExcelLib.ReadData(1, "beginDate"));
        }

        [TearDown]
        public void CloseTest()
        {
            driver.Quit();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }



    }
}
