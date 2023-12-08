using ModuleTest.PageObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TataCliq.Utilities;

namespace ModuleTest.TestScripts
{
    [TestFixture]
    internal class CourseEnrollTest : CoreCodes
    {
        [Test, Order(3), Category("Smoke Test")]
        public void CourseEnrollPage()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            try
            {
            Courses c = new(driver);
            c.CourseEnroll();
            List<string> str = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(str[1]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            TakeScreenShot();
            Assert.That(driver.Url, Does.Contain("selenium"));
            LogTestResult("Smoke Test", "Smoke Test Passed");
            test = extent.CreateTest("Smoke Test Passed");
            test.Pass("Smoke Test Passed");
             }
            catch (AssertionException ex)
             {
               TakeScreenShot();
               LogTestResult("Smoke Test", "Smoke Test Failed", ex.Message);
               test.Fail("Smoke Test Failed");
             }
         
        }
     

    }
}
