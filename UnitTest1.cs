using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace SeleniumCore
{
    [TestClass]
    public class WebAppTest
    {
        [TestMethod]
        public void NavigateToUrl()
        {
            var OutputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(OutputDirectory); //Initialize the diver 

            driver.Navigate().GoToUrl("https://www.saucedemo.com/"); //Driver navigates to the site of the given url
        }
    }
}
