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
        
        public void NegativeTestNullValues()
        {
            WaitHelpers.WaitToExists("XPath", "//a[@class='ui basic green button']", 10);
            shareSkillButton.Click();
            
            save.Click();

            string titleError = driver.FindElement(By.XPath("//div[2]/div/form/div[1]/div/div[2]/div/div[2]/div")).Text;
            string descriptionError = driver.FindElement(By.XPath("//div[2]/div/form/div[2]/div/div[2]/div[2]/div")).Text;
            string categoryError = driver.FindElement(By.XPath("//div[2]/div/form/div[3]/div[2]/div[2]")).Text;
            string addTagsError = driver.FindElement(By.XPath("//div[2]/div/form/div[4]/div[2]/div[2]")).Text;
            string skillTagsError = driver.FindElement(By.XPath("//div[2]/div/form/div[8]/div[4]/div[2]")).Text;

            Assert.That(titleError == "Title is required", "Title field accepts null values");
            Assert.That(descriptionError == "Description is required", "Description field accepts null values");
            Assert.That(categoryError == "Category is required", "Category field accepts null values");
            Assert.That(addTagsError == "Tags are required", "Add Tags field accepts null values");
            Assert.That(skillTagsError == "Tag is required", "Skill Tags field accepts null values");

           
        }

        public void NegativeTestInvalidValues(string title, string description,string category, string beginDate)
        {
            WaitHelpers.WaitToExists("XPath", "//a[@class='ui basic green button']", 10);
            shareSkillButton.Click();
            titleTextbox.Click();
            titleTextbox.SendKeys(title);
            descriptionTextbox.Click();
            descriptionTextbox.SendKeys(description);
            categoryDropdownMenu.Click();
            SelectElement oSelect = new SelectElement(categoryDropdownMenu);
            oSelect.SelectByText(category);
            startDate.SendKeys(beginDate);
            save.Click();
            
            int titleLength = title.Length;
            int descriptionLength = description.Length;
            string titleError = driver.FindElement(By.XPath("//div[2]/div/form/div[1]/div/div[2]/div/div[2]/div")).Text;
            string descriptionError = driver.FindElement(By.XPath("//div[2]/div/form/div[2]/div/div[2]/div[2]/div")).Text;
            Thread.Sleep(2000);
            string categoryError = driver.FindElement(By.XPath("//div[2]/div/form/div[3]/div[2]/div/div[2]/div[2]/div")).Text;
            string dateError = driver.FindElement(By.XPath("//div[2]/div/form/div[7]/div[2]/div[2]")).Text;
            Console.WriteLine(titleLength);
            Assert.That(titleLength == 100, "Title textbox accepts more than 100 characters");
            Assert.That(descriptionLength == 600, "Description textt box accepts more than 600 characters");
            Assert.That(titleError == "Special characters are not allowed.", "Title field accepts null values");
            Assert.That(descriptionError == "First character must be an alphabet character or a number.", "Description field accepts null values");
            Assert.That(categoryError == "Subcategory is required", "Category field accepts null values");
            Assert.That(dateError == "Start Date cannot be set to a day in the past", "Date field accepts past date");

        }

    }
}

