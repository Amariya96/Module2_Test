using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTest.PageObjects
{
    internal class Courses
    {
        IWebDriver driver;
        public Courses(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Courses']")]
        private IWebElement? CoursesPage { get; set; }

        [FindsBy(How = How.XPath, Using = "(//h2[@id='selenium-webdriver-with-java-for-beginners'])[1]")]
        private IWebElement? Link { get; set; }

        public void CourseEnroll()
        {
            CoursesPage?.Click();
            Link?.Click();
        }
    }
}
