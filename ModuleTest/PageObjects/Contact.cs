using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTest.PageObjects
{
    internal class Contact
    {

        IWebDriver driver;
        public Contact(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Contact']")]
        private IWebElement? Contactpage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='wpforms-161-field_0']")]
        private IWebElement? Name { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='wpforms-161-field_0-last']")]
        private IWebElement? LastName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='wpforms-161-field_1']")]
        private IWebElement? Email { get; set; }
        [FindsBy(How = How.XPath, Using = "//textarea[@id='wpforms-161-field_2']")]
        private IWebElement? Notes { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='wpforms-recaptcha-container wpforms-is-recaptcha']")]
        private IWebElement? Captcha { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@id='wpforms-submit-161']")]
        private IWebElement? SubmitBtn { get; set; }
       
        
        public void ContactDetails(string na, string ln, string email, string text)
        {
            Contactpage?.Click();
            Name?.SendKeys(na);
            LastName?.SendKeys(ln);
            Email?.SendKeys(email);
            Notes?.SendKeys(text);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Captcha?.Click();
            SubmitBtn?.Click();

        }
        
       
    }
}
