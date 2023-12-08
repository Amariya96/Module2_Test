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
    internal class LoginPageTest : CoreCodes   //Inheritance
    {
        [Test, Order(1)]
        public void LoginTest()
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
                    string? userName = excelData?.UserName;
                    string? password = excelData?.Pwd;
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    Login l = new(driver);
                    l.LoginPage(userName,password);
                    TakeScreenShot();
                    Assert.That(driver.Url, Does.Contain("practicetestautomation"));
                    LogTestResult("Login Test", "Login Passed");
                    test = extent.CreateTest("Login Test Passed");
                    test.Pass("Login Test Passed");
                }
                catch (AssertionException ex)
                {
                    TakeScreenShot();
                    LogTestResult("Login Test", "Login Test Failed", ex.Message);
                    test.Fail("Login Test Failed");
                }
            }
        }
       
    }
}
