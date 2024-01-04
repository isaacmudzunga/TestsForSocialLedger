using System;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Scenarios
{
    public class GaugeSupport
    {
        private static IWebDriver _driver;

        // This class provides a singleton web driver. Use it in your page object classes.
        public static IWebDriver Driver
        {
            get => _driver;
            private set => _driver = value;
        }

        [BeforeSpec]
        public void BeforeSpec()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterSpec]
        public void AfterSpec()
        {  
             _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Close();
        }
    }
}
