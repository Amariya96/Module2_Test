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
    internal class ContactTest : CoreCodes
    {
        [Test, Order(2)]
        public void ContactPageTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "ModuleTest";

            List<SearchData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                try
                {
                    string? name = excelData?.Name;
                    string? lastName = excelData?.LastName;
                    string? email = excelData?.Email;
                    string? content = excelData?.Content;
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    Contact c = new(driver);
                    c.ContactDetails(name,lastName,email,content);
                    TakeScreenShot();
                    Assert.That(driver.Url, Does.Contain("contact"));
                    LogTestResult("ContactPage Test", "ContactPage Passed");
                    test = extent.CreateTest("ContactPage Test Passed");
                    test.Pass("ContactPage Test Passed");
                }
                catch (AssertionException ex)
                {
                    TakeScreenShot();
                    LogTestResult("ContactPage Test", "ContactPage Test Failed", ex.Message);
                    test.Fail("ContactPage Test Failed");
                }
            }
        }
    }
}
