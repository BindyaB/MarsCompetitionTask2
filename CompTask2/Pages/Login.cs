using CompTask2.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompTask2.Pages
{
    public class Login:CommonDriver
    {

        //public Login()
        //{
        //    PageFactory.InitElements(driver, this);

        //}

        //[FindsBy(How = How.XPath, Using = "//a[@class='item']")]
        //public IWebElement signInButton;

        //[FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        //public IWebElement emailAddressTextbox;

        //[FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        //public IWebElement passwordTextBox;

        //[FindsBy(How = How.XPath, Using = "//button[@class='fluid ui teal button']")]
        //public IWebElement loginButton;


        public static IWebElement signInButton => driver.FindElement(By.XPath("//a[@class='item']"));
        public static IWebElement emailAddressTextbox => driver.FindElement(By.XPath("//input[@name='email']"));
        public static IWebElement passwordTextBox => driver.FindElement(By.XPath("//input[@name='password']"));
        public static IWebElement loginButton => driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));


        public Login(string url, string username, string password)
        {

            //driver.Manage();
            driver.Manage().Window.Maximize();
            //launch local host 5000

            driver.Navigate().GoToUrl(url);
            WaitHelpers.WaitToBeClickable("XPath", "//a[@class='item']", 10);

            signInButton.Click();
            emailAddressTextbox.SendKeys(username);
            passwordTextBox.SendKeys(password);
            loginButton.Click();

        }

    }
}
