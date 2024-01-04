using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Scenarios.Pages
{
    public class ViewPaymentMadePage
    {
        private const string Url = "http://localhost:5050";
        private static readonly IWebDriver Driver = GaugeSupport.Driver;

        public ViewPaymentMadePage Open()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        public ViewPaymentMadePage clickExpense()
        {
            Driver.FindElement(By.Id("payment_request_1")).Click();
            return this;
        }

    }
}