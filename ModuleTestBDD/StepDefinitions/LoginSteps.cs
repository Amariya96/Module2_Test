using ModuleTestBDD.Hooks;
using ModuleTestBDD.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ModuleTestBDD.StepDefinitions
{
    [Binding]
    internal class LoginSteps :CoreCodes
    {
        IWebDriver? driver = BeforeHooks.driver;
        [When(@"User click on the Login Page")]
        public void WhenUserClickOnTheLoginPage()
        {
            IWebElement practicePage = driver.FindElement(By.Id("menu-item-20"));
            practicePage.Click();
        }

        [Then(@"Login page will be loaded")]
        public void ThenLoginPageWillBeLoaded()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("practice"));
                LogTestResult("Practice Page Test ", "Practice Page success");
                ;
            }
            catch (AssertionException ex)
            {
                LogTestResult("Practice Page Test",
                  "Practice Page  failed", ex.Message);
            }
        }

        [When(@"User click on the Test Login Page")]
        public void WhenUserClickOnTheTestLoginPage()
        {
            IWebElement testLoginPage = driver.FindElement(By.XPath("//a[normalize-space()='Test Login Page']"));
            testLoginPage.Click();
        }

        [Then(@"Test Login Page will be loaded")]
        public void ThenTestLoginPageWillBeLoaded()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("practice"));
                LogTestResult("Test Login Page Test ", "Test Login Page success");
                ;
            }
            catch (AssertionException ex)
            {
                LogTestResult("Test Login Page Test",
                  "Test Login Page  failed", ex.Message);
            }
        }

        [When(@"User will enter '([^']*)', '([^']*)'")]
        public void WhenUserWillEnter(string username, string password)
        {
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeys(username);
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys(password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [When(@"User will click on the submit button")]
        public void WhenUserWillClickOnTheSubmitButton()
        {
            IWebElement submitBtn = driver.FindElement(By.XPath(" //button[@id='submit']"));
            submitBtn.Click();          
        }
        [Then(@"Login is completed")]
        public void ThenLoginIsCompleted()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("practicetestautomation"));
                LogTestResult("Login Page Test ", "Login Page success");
                ;
            }
            catch (AssertionException ex)
            {
                LogTestResult("Login Page Test",
                  "Login Page  failed", ex.Message);
            }
        }

    }
}
