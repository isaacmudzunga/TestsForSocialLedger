using System.Collections.ObjectModel;
using FluentAssertions;
using OpenQA.Selenium;
using static Scenarios.GaugeSupport;

namespace Scenarios.Pages
{
    public class RequestPage
    {
        private const string Url = "http://localhost:5050";
        private static readonly IWebDriver Driver = GaugeSupport.Driver;

        private static IWebElement ExpenseLink => Driver.FindElement(By.Id("payment_request_2"));
        private static IWebElement RequestsSentLink => Driver.FindElement(By.Id("paymentrequests_sent"));
       private static IWebElement AmountField => Driver.FindElement(By.Id("amount"));
        private static IWebElement EmailField => Driver.FindElement(By.Id("email"));
        private static IWebElement DateField => Driver.FindElement(By.Id("due_date"));
        private static IWebElement RequestButton => Driver.FindElement(By.Id("submit"));

        public RequestPage Open()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        public ResultsPage OpenExpense()
        {
            ExpenseLink.Click();
            return new ResultsPage();
        }

        public ResultsPage OpenRequestSents()
        {
            RequestsSentLink.Click();
            return new ResultsPage();
        }
        

        public ResultsPage CreateExpenseRequest(string email, string date, string amount)
        {
            EmailField.SendKeys(email);
            AmountField.SendKeys(amount);
            DateField.SendKeys(date);
            RequestButton.Click();
            return new ResultsPage();;
        }
    }
}
