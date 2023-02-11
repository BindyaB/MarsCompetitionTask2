using CompTask2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompTask2.Pages
{
    public class Login:CommonDriver
    {
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
            WaitHelpers.WaitToBeClickable("XPath", "//a[@class='item']", 5);

            signInButton.Click();
            emailAddressTextbox.SendKeys(username);
            passwordTextBox.SendKeys(password);
            loginButton.Click();

        }

    }
}
