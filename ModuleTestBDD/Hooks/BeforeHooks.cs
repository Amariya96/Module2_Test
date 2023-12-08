using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Serilog;
using TechTalk.SpecFlow;

namespace ModuleTestBDD.Hooks
{
    [Binding]
    public sealed class BeforeHooks
    {
        public static IWebDriver? driver;

        [BeforeFeature(Order = 1)]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }

        [BeforeFeature(Order = 2)]
        public static void LogFileCreation()
        {
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy.mm.dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        [AfterFeature]
        public static void CleanUp()
        {
            BeforeHooks.driver?.Quit();
        }

        [AfterScenario]
        public static void NavigateToHomePage()
        {
            BeforeHooks.driver?.Navigate().GoToUrl("https://practicetestautomation.com/");
        }
    }
}