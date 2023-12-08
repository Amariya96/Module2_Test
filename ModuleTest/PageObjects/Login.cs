using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTest.PageObjects
{
    internal class Login
    {
        IWebDriver driver;
        public Login(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "menu-item-20")]
        private IWebElement? Practice { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Test Login Page']")]
        private IWebElement? TestLogin { get; set; }

        [FindsBy(How = How.XPath, Using = " //input[@id='username']")]
        private IWebElement? Username { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        private IWebElement? Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='submit']")]
        private IWebElement? SubmitBtn { get; set; }

        [FindsBy(How = How.XPath, Using = " //a[@class='wp-block-button__link has-text-color has-background has-very-dark-gray-background-color']")]
        private IWebElement? LogoutBtn { get; set; }
       
        public void LoginPage(string un, string pd)
        {
            Practice?.Click();
            TestLogin?.Click();
            Username?.SendKeys(un);
            Password?.SendKeys(pd);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SubmitBtn?.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            LogoutBtn?.Click();
            Username?.SendKeys("incorrectUser");
            Password?.SendKeys("Password123");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SubmitBtn?.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Username?.SendKeys("student");
            Password?.SendKeys("incorrectPassword");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            SubmitBtn?.Click();
        }
    }
}
