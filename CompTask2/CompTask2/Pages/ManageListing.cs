using CompTask2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace CompTask2.Pages
{
   public class ManageListing:CommonDriver
    {
        public ManageListing()
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[@href='/Home/ListingManagement']")]
        public  IWebElement manageListingLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='eye icon']")]
        public IWebElement eyeIcon;

        [FindsBy(How = How.XPath, Using = "//div[@class='active section']")]
        public IWebElement viewListing;

        [FindsBy(How = How.XPath, Using = "//i[@class='outline write icon']")]
        public IWebElement writeIcon;

        [FindsBy(How = How.Name, Using = "title")]
        public IWebElement titleTextbox;

        [FindsBy(How = How.Name, Using = "description")]
        public IWebElement descriptionTextbox;

        [FindsBy(How = How.XPath, Using = "//div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        public IWebElement addTags;

        [FindsBy(How = How.Name, Using = "skillTrades")]
        public IList<IWebElement> skillTrade;

        [FindsBy(How = How.XPath, Using = "//div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        public IWebElement skillTags;

        [FindsBy(How = How.Name, Using = "charge")]
        public IWebElement credit;

        [FindsBy(How = How.XPath, Using = "//input[@type='button'and@value='Save']")]
        public IWebElement save;

        [FindsBy(How = How.XPath, Using = "//i[@class = 'remove icon']")]
        public IWebElement deleteIcon;

        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button']")]
        public IWebElement deleteYesbutton;

        

        // this is passed from  the test.
        public ShareSkill varShareSkill;

        public string ViewListing()
        {
            WaitHelpers.WaitToExists("XPath", "//a[@href='/Home/ListingManagement']", 4);
            manageListingLink.Click();
            WaitHelpers.WaitToExists("XPath", "//i[@class='eye icon']", 3);
            eyeIcon.Click();
            string header = viewListing.Text;
            Console.WriteLine(header);
            Assert.That(header == "Ballet Dancer", "Listing not found");
            return header;


        }

        public void EditListing(string title, string description, string addtags, string skilltrade, string skilltags, string charge)
        {
            WaitHelpers.WaitToExists("XPath", "//a[@href='/Home/ListingManagement']", 4);
            manageListingLink.Click();
            WaitHelpers.WaitToExists("XPath", "//i[@class='outline write icon']", 3);
            writeIcon.Click();
            WaitHelpers.WaitToExists("Name", "title", 3);
            titleTextbox.Clear();
            titleTextbox.SendKeys(title);
            descriptionTextbox.SendKeys(description);
            addTags.SendKeys(addtags);

            if (skilltrade == "Skill-exchange")
            {
                IWebElement skillElement = skillTrade[0];
                skillElement.Click();
                skillTags.SendKeys(skilltags);
                skillTags.SendKeys(Keys.Enter);
            }
            if (skilltrade == "Credit")
            {
                IWebElement skillElement = skillTrade[1];
                skillElement.Click();
                credit.SendKeys(charge);
            }

            save.Click();

            WaitHelpers.WaitToExists("XPath", "//div[2]/div[1]/div[1]/table/tbody/tr/td[3]", 3);
            var manageLisitngTitle = driver.FindElement(By.XPath("//div[2]/div[1]/div[1]/table/tbody/tr/td[3]"));
            string checkTitle = manageLisitngTitle.Text;
            string expectedTitle = "All ages Ballet Dancer";
            Assert.That(checkTitle == expectedTitle, "Service listing not updated");


        }

        public void DeleteListing()
        {
            WaitHelpers.WaitToExists("XPath", "//a[@href='/Home/ListingManagement']", 4);
            manageListingLink.Click();
            WaitHelpers.WaitToExists("XPath", "//i[@class = 'remove icon']", 5);
            deleteIcon.Click();
            deleteYesbutton.Click();
            WaitHelpers.WaitToExists("CssSelector", "div.ns-effect-jelly", 5);
            Thread.Sleep(3000);
            var alertMessage = driver.FindElement(By.CssSelector("div.ns-effect-jelly")).Text;
            Assert.IsTrue(alertMessage.Contains(" has been deleted"));

        }
    
    }
}
