using AutoItX3Lib;
using CompTask2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;


namespace CompTask2.Pages
{
    public class ShareSkill:CommonDriver
    {

       public ShareSkill()
        {
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        public IWebElement shareSkillButton;

        [FindsBy(How = How.Name, Using = "title")]
        public  IWebElement titleTextbox;

        [FindsBy(How = How.Name, Using = "description")]
        public  IWebElement descriptionTextbox;

        [FindsBy(How = How.Name, Using = "categoryId")]
        public  IWebElement categoryDropdownMenu;

        [FindsBy(How = How.Name, Using = "subcategoryId")]
        public  IWebElement subcategoryDropDown;

        [FindsBy(How = How.XPath, Using = "//div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        public  IWebElement addTags;

        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType'and@value='0']")]
        public  IWebElement hourlyBasisService;

        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType'and@value='1']")]
        public  IWebElement oneOffService;

        [FindsBy(How = How.XPath, Using = "//input[@name='locationType'and@value='0']")]
        public  IWebElement onsite;

        [FindsBy(How = How.XPath, Using = "//input[@name='locationType'and@value='1']")]
        public  IWebElement online;

        [FindsBy(How = How.Name, Using = "startDate")]
        public  IWebElement startDate;

        [FindsBy(How = How.Name, Using = "endDate")]
        public  IWebElement endDate;

        [FindsBy(How = How.Name, Using = "Available")]
        public  IList<IWebElement> availableDays { get; set; }

        [FindsBy(How = How.Name, Using = "StartTime")]
        public  IList<IWebElement> beginTime;

        [FindsBy(How = How.Name, Using = "EndTime")]
        public  IList<IWebElement> finishTime;

        [FindsBy(How = How.Name, Using = "skillTrades")]
        public  IList<IWebElement> skillTrade;

        [FindsBy(How = How.XPath, Using = "//div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        public  IWebElement skillTags;

        [FindsBy(How = How.Name, Using = "charge")]
        public  IWebElement credit;

        [FindsBy(How = How.XPath, Using = "//div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        public  IWebElement attachFile;

        [FindsBy(How = How.Name, Using = "isActive")]
        public  IList<IWebElement> status;

        [FindsBy(How = How.XPath, Using = "//input[@type='button'and@value='Save']")]
        public IWebElement save;

        [FindsBy(How = How.XPath, Using = "//a[@href='/Home/ListingManagement']")]
        public IWebElement manageListingLink;

        [FindsBy(How = How.XPath, Using = "//div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")]
        public IWebElement listTitle;
        


        public void AddShareSkill(string title, string description, string category, string subcategory,
                                    string addtags, string serviceType, string locationType, string daysAvaialable, string beginDate,
                                    string finishDate, string starttime, string endtime, string skilltrade, string skilltags, string charge,
                                    string active)
        {
            WaitHelpers.WaitToExists("XPath", "//a[@class='ui basic green button']", 10);
            shareSkillButton.Click();
            titleTextbox.Click();
            titleTextbox.SendKeys(title);
            descriptionTextbox.Click();
            descriptionTextbox.SendKeys(description);
            // WaitHelpers.WaitToExists("Name", "categoryId", 6);
            categoryDropdownMenu.Click();
            SelectElement oSelect = new SelectElement(categoryDropdownMenu);
            oSelect.SelectByText(category);
            //WaitHelpers.WaitToExists("Name", "subcategoryId", 6);
            subcategoryDropDown.Click();
            SelectElement sSelect = new SelectElement(subcategoryDropDown);
            sSelect.SelectByText(subcategory);
            addTags.Click();
            addTags.SendKeys(addtags);
            addTags.SendKeys(Keys.Enter);



            if (serviceType == "Hourly basis service")
            {
                hourlyBasisService.Click();
            }
            else
            {
                oneOffService.Click();
            }

            if (locationType == "On-site")
            {
                onsite.Click();
            }
            else
            {
                online.Click();
            }

            startDate.SendKeys(beginDate);
            endDate.SendKeys(finishDate);

            // Available days
            int selElementIndex = 0;
            if (daysAvaialable == "Sun")
            {
                selElementIndex = 0;
            }
            if (daysAvaialable == "Mon")
            {
                selElementIndex = 1;
            }
            if (daysAvaialable == "Tue")
            {
                selElementIndex = 2;
            }
            if (daysAvaialable == "Wed")
            {
                selElementIndex = 3;
            }
            if (daysAvaialable == "Thu")
            {
                selElementIndex = 4;
            }
            if (daysAvaialable == "Fri")
            {
                selElementIndex = 5;
            }
            if (daysAvaialable == "Sat")
            {
                selElementIndex = 6;
            }

            IWebElement avlElement = availableDays[selElementIndex];
            avlElement.Click();
            IWebElement beginTimeElement = beginTime[selElementIndex];
            beginTimeElement.SendKeys(starttime);
            IWebElement finishTimeElement = finishTime[selElementIndex];
            finishTimeElement.SendKeys(endtime);



            // Skill trade
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
            // Active
            if (active == "Active")
            {
                IWebElement activeStatus = status[0];
                activeStatus.Click();
            }
            if (active == "Hidden")
            {
                IWebElement activeStatus = status[1];
                activeStatus.Click();
            }



            attachFile.Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(2000);
            autoIt.Send(@"C:\Lemon.jpg");
            Thread.Sleep(2000);
            autoIt.Send("{ENTER}");
            WaitHelpers.WaitToExists("XPath", "//input[@type='button'and@value='Save']", 5);
            save.Click();

            WaitHelpers.WaitToExists("XPath", "//a[@href='/Home/ListingManagement']", 10);
            manageListingLink.Click();
            WaitHelpers.WaitToExists("XPath", "//div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]", 10);
            var listadded = listTitle.Text;
            Assert.That(listadded == "Ballet Dancer", "Listing not found");


        }
        

    }
}
