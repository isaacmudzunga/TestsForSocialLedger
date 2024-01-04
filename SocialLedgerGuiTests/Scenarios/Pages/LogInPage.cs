using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Scenarios.Pages
{
    public class LogInPage
    {
        private const string Url = "http://localhost:5050";
        private static readonly IWebDriver Driver = GaugeSupport.Driver;
         private static IWebElement EmailField => Driver.FindElement(By.Id("email"));
        private static IWebElement LogInButton => Driver.FindElement(By.Id("submit"));
        

        public LogInPage Open()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        public LogInPage enterLogInEmail(string email)
        {
            Driver.FindElement(By.Id("email")).SendKeys(email);
            return this;
        }

        public LogInPage clickLogInButton()
        {
            Driver.FindElement(By.Id("submit")).Click();
            return this;
        }

        public LogInPage clickPaymentRequestSentTab()
        {
            Driver.FindElement(By.Id("paymentrequests_sent")).Click();
            return this;
        }

        public LogInPage clickPaymentRequestReceivedTab()
        {
            Driver.FindElement(By.Id("paymentrequests_received")).Click();
            return this;
        }

        public LogInPage clickLogOutTab()
        {
            Driver.FindElement(By.Id("logout")).Click();
            return this;
        }

         public ResultsPage LogIn(string email)
        {
            EmailField.SendKeys(email);
            LogInButton.Click();
            return new ResultsPage();
        } 
    }
}