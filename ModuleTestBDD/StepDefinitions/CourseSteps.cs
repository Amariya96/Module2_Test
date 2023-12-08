using ModuleTestBDD.Hooks;
using ModuleTestBDD.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace ModuleTestBDD.StepDefinitions
{
    [Binding]
    internal class CourseSteps :CoreCodes
    {
        IWebDriver? driver = BeforeHooks.driver;
        [When(@"User click on coursepage")]
        public void WhenUserClickOnCoursepage()
        {
            IWebElement coursePage = driver.FindElement(By.XPath("//a[normalize-space()='Courses']"));
            coursePage.Click();
        }

        [Then(@"Course page will be loaded")]
        public void ThenCoursePageWillBeLoaded()
        {

            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("courses"));
                LogTestResult("Course Page Test ", "Course Page success");
                ;
            }
            catch (AssertionException ex)
            {
                LogTestResult("Course Page Test",
                  "Course Page  failed", ex.Message);
            }
        }

        [When(@"Userclick on the link")]
        public void WhenUserclickOnTheLink()
        {
            IWebElement LinkPage = driver.FindElement(By.XPath("(//h2[@id='selenium-webdriver-with-java-for-beginners'])[1]"));
            LinkPage.Click();
        }

        [Then(@"Course link will be opened")]
        public void ThenCourseLinkWillBeOpened()
        {

            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("practice"));
                LogTestResult("Link Page Test ", "Link Page success");
                ;
            }
            catch (AssertionException ex)
            {
                LogTestResult("Link Page Test",
                  "Link Page  failed", ex.Message);
            }
        }
    }
}
