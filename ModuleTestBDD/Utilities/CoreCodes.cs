using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTestBDD.Utilities
{
    internal class CoreCodes
    {
        protected void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot its = (ITakesScreenshot)driver;
            Screenshot ss = its.GetScreenshot();
            string currentDirectory = Directory.GetParent(@"../../../").FullName;

            string filePath = currentDirectory + "/Screenshot/ss_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".png";
            ss.SaveAsFile(filePath);

        }

        protected void LogTestResult(string testName, string result, string errorMessage = null)
        {


            Log.Information(result);

            if (errorMessage == null)
            {
                Log.Information(testName + "Passed");


            }
            else
            {
                Log.Error($"Test failed for{testName}.\n Exception: \n{errorMessage}");

            }
        }
        public static DefaultWait<IWebDriver> Waits(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(40);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";

            return fluentWait;
        }
        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", element);
        }

    }
}
