using FluentAssertions;
using OpenQA.Selenium;
using static Scenarios.GaugeSupport;

namespace Scenarios.Pages
{
    public class HomePage
    {
        private const string Url = "http://localhost:5050";
        private static readonly IWebDriver Driver = GaugeSupport.Driver;


        public HomePage Open()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        public ResultsPage HomePageResults()
        {
            return new ResultsPage("WeShare");
        }
    }
}