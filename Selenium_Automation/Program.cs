using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Automation
{
    internal class Program
    {
        // Create a reference for Chrome browser
        IWebDriver driver = new ChromeDriver();

        
        static void Main(string[] args)
        {
                      
        }
        [SetUp]
        public void Initialize()
        {
            // Go to Google Page
            driver.Navigate().GoToUrl("https://www.amazon.com");
        }

        [Test]
        public void ExecuteTheTest()
        {
            // Make the browser full screen
            driver.Manage().Window.Maximize();

            IWebElement SignIn = driver.FindElement(By.Id("nav-link-accountList"));
            SignIn.Click();

            IWebElement EmailField = driver.FindElement(By.Id("ap_email"));
            EmailField.SendKeys("pewpew@abv.bg");

            IWebElement ContinueButton = driver.FindElement(By.ClassName("a-button-input"));
            ContinueButton.Click();

            IWebElement ErrorMessage = driver.FindElement(By.ClassName("a-alert-heading"));
            string ActualErrorMessageText = ErrorMessage.Text;
            string ExpectedErrorMessageText = "There was a problem";
            //Assert.That(Equals(ActualErrorMessageText, ExpectedErrorMessageText));
            NUnit.Framework.Legacy.ClassicAssert.AreEqual(ExpectedErrorMessageText, ActualErrorMessageText);

        }
        [TearDown]
        public void CloseTest()
        {
            // Close the browser
            driver.Quit();
        }
    }
}
