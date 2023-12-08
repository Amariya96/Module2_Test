using ModuleTestBDD.Hooks;
using ModuleTestBDD.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ModuleTestBDD.StepDefinitions
{
    [Binding]
    internal class ContactSteps :CoreCodes
    {
        IWebDriver? driver = BeforeHooks.driver;
        [Given(@"User will be on Homepage")]
        public void GivenUserWillBeOnHomepage()
        {
            driver.Url = "https://practicetestautomation.com/";
            driver.Manage().Window.Maximize();
        }

        [When(@"User will click on the contact page")]
        public void WhenUserWillClickOnTheContactPage()
        {
            IWebElement contactPage = driver.FindElement(By.XPath("//a[normalize-space()='Contact']"));
            contactPage.Click();
        }

        [Then(@"Contact Page will be loaded")]
        public void ThenContactPageWillBeLoaded()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("contact"));
                LogTestResult("Contact Page Test ", "Contact Page success");
                ;
            }
            catch (AssertionException ex)
            {
                LogTestResult("Contact Page Test",
                  "Contact Page  failed", ex.Message);
            }
        }

        [When(@"User will enter '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenUserWillEnter(string kavi, string mohan, string p2, string p3)
        {
            driver.FindElement(By.XPath("//input[@id='wpforms-161-field_0']")).SendKeys(kavi);
            driver.FindElement(By.XPath("//input[@id='wpforms-161-field_0-last']")).SendKeys(mohan);
            driver.FindElement(By.XPath("//input[@id='wpforms-161-field_1']")).SendKeys(p2);
            driver.FindElement(By.XPath("//textarea[@id='wpforms-161-field_2']")).SendKeys(p3);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [When(@"User will click on the captcha button")]
        public void WhenUserWillClickOnTheCaptchaButton()
        {
            IWebElement captchaBtn = driver.FindElement(By.XPath("//div[@class='wpforms-recaptcha-container wpforms-is-recaptcha']"));
            captchaBtn.Click();
        }

        [When(@"User will click on submit button")]
        public void WhenUserWillClickOnSubmitButton()
        {
            IWebElement submitBtn = driver.FindElement(By.XPath("//button[@id='wpforms-submit-161']"));
            submitBtn.Click();
        }

        [Then(@"Created login page will be loaded")]
        public void ThenCreatedLoginPageWillBeLoaded()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("contact"));
                LogTestResult("Contact Details Test ", "Contact Details success");
                ;
            }
            catch (AssertionException ex)
            {
                LogTestResult("Contact Details Test",
                  "Contact Details failed", ex.Message);
            }
        }
    }
}
