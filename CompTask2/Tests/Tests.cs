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
        
        [SetUp]
        public void LoginActions()
        {
           
           driver = new ChromeDriver();
                                    
        }


        [Test, Order(1)]
        public void ACreateShareSkill()
        {
            ShareSkill shareSkillObj = new ShareSkill();

            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataShareskill.xlsx", "LoginDetails");
            Login loginObj = new Login(ExcelLib.ReadData(1, "url"), ExcelLib.ReadData(1, "username"), ExcelLib.ReadData(1, "password"));


            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataShareskill.xlsx", "ShareSkill");
            
            shareSkillObj.AddShareSkill(ExcelLib.ReadData(1, "title"), ExcelLib.ReadData(1, "description"), ExcelLib.ReadData(1, "category"),
                ExcelLib.ReadData(1, "subcategory"), ExcelLib.ReadData(1, "addtags"), ExcelLib.ReadData(1, "serviceType"), ExcelLib.ReadData(1, "locationType"),
                ExcelLib.ReadData(1, "daysAvaialable"), ExcelLib.ReadData(1, "beginDate"), ExcelLib.ReadData(1, "finishDate"), ExcelLib.ReadData(1, "starttime"),
                ExcelLib.ReadData(1, "endtime"), ExcelLib.ReadData(1, "skilltrade"), ExcelLib.ReadData(1, "skilltags"), ExcelLib.ReadData(1, "charge"),
                ExcelLib.ReadData(1, "active"));
                    
        }

        

        [Test, Order(2)]
        public void BViewManageListing()
        {
                        
            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataViewListing.xlsx", "LoginDetails");
            
            Login loginObj = new Login(ExcelLib.ReadData(1, "url"), ExcelLib.ReadData(1, "username"), ExcelLib.ReadData(1, "password"));
            
            ManageListing manageListingObj = new ManageListing();
            manageListingObj.ViewListing();

        }

        [Test, Order(3)]
        public void CEditManageListing()
        {
                       
            ManageListing manageListingObj = new ManageListing();

            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataEditShareSkill.xlsx", "LoginDetails");
            Login loginObj = new Login(ExcelLib.ReadData(1, "url"), ExcelLib.ReadData(1, "username"), ExcelLib.ReadData(1, "password"));
            
            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataEditShareSkill.xlsx", "EditShareSkill");
            manageListingObj.EditListing(ExcelLib.ReadData(1, "title"), ExcelLib.ReadData(1, "description"), ExcelLib.ReadData(1, "addtags"), ExcelLib.ReadData(1, "skilltrade"),
                                          ExcelLib.ReadData(1, "skilltags"), ExcelLib.ReadData(1, "charge"));
            
           

        }

        [Test, Order(4)]
        public void DeleteManageListing()
        {
            ExcelLib.PopulateInCollection(@"C:\IndustryConnect\CompetitionTask\MarsCompetitionTask2\CompTask2\TestDataDeleteListing.xlsx", "LoginDetails");
            Login loginObj = new Login(ExcelLib.ReadData(1, "url"), ExcelLib.ReadData(1, "username"), ExcelLib.ReadData(1, "password"));

            ManageListing manageListingObj = new ManageListing();
            manageListingObj.DeleteListing();
            
           
        }

        [TearDown]
        public void CloseTest()
        {
            driver.Quit();
        }





    }
}
