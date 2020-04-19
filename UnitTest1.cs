using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCore
{
    [TestClass]
    public class WebAppTest
    {
        IWebDriver _driver; //Class Variable is created (Global Variable)

        [TestMethod]
        public void NavigateToUrlAndLogin()
        {
            var OutputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(OutputDirectory); //Initialize the class variable

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/"); //Driver navigates to the site of the given url

            var LocateLoginBtn = By.ClassName("btn_action"); //Locates an element with that class name on the webpage

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); //The page waits for 10 Seconds
            wait.Until(ExpectedConditions.ElementIsVisible(LocateLoginBtn)); //wait condition time set before it locates the element on the webpage

            
            //Elements in the login form to interact with the page 

            var userNameField = _driver.FindElement(By.Id("user-name")); //the username 
            var passWordField = _driver.FindElement(By.Id("password")); //the password 
            var LoginBtn = _driver.FindElement(LocateLoginBtn); //the loginbtn 


            //input values into the element

            userNameField.SendKeys("standard_user");
            passWordField.SendKeys("secret_sauce");
            LoginBtn.Click();

            Assert.IsTrue(_driver.Url.Contains("inventory.html")); //Checks if the login was actually successful
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit(); //Terminated the ChromeDriver automatically
        }
    }
}
