using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Scenarios.Pages
{
    public class PaymentPage
    {
        private const string Url = "http://localhost:5050";

        public IWebDriver Driver = GaugeSupport.Driver;

        public void NavigateToHomePage()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public PaymentPage logIn(string email)
        {
            Driver.FindElement(By.Id("email")).SendKeys(email);
            Driver.FindElement(By.Id("submit")).Click();
            return this;
        }

        public PaymentPage navigateTopRRTab()
        {
            Driver.FindElement(By.Id("paymentrequests_received")).Click();
            return this;
        }

        public PaymentPage clickPayForExpense()
        {
            Driver.FindElement(By.ClassName("inline")).Click();
            return this;
        }

        public PaymentPage navigateBackToExpansePage()
        {
            Driver.FindElement(By.Id("expense")).Click();
            return this;
        }
    }
}