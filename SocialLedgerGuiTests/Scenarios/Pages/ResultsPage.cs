using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Scenarios;


namespace Scenarios.Pages
{
    public class ResultsPage
    {
        private readonly string _text;

        public ResultsPage(string text)
        {
            _text = text;
        }
         public ResultsPage()
        {
        }

        public ResultsPage isCorrectTitle()
        {
            GaugeSupport.Driver.Title.Should().StartWith(_text);
            return this;
        }

        public ResultsPage alertMessage()
        {
            var alertMessage = GaugeSupport.Driver.FindElement(By.XPath("/html/body/p"));
            alertMessage.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage displayUserEmail()
        {
            var userEmail = GaugeSupport.Driver.FindElement(By.XPath("/html/body/p"));
            userEmail.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage pagePageHeader()
        {
            var pageHeader = GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section/h2"));
            pageHeader.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage alertPerson()
        {
            var alertPerson = GaugeSupport.Driver.FindElement(By.Id("no_expenses"));
            alertPerson.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage requestSentAlert()
        {
            var requestSentAlert = GaugeSupport.Driver.FindElement(By.Id("no_payment_requests_sent"));
            requestSentAlert.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage requestsReceivedAlert()
        {
            var requestsReceivedAlert = GaugeSupport.Driver.FindElement(By.Id("no_payment_requests_received"));
            requestsReceivedAlert.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage expenseViewHeader()
        {
            var expenseViewHeader = GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section/h2"));
            expenseViewHeader.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage expensesTotal()
        {
            var expensesTotal = GaugeSupport.Driver.FindElement(By.Id("grand_total"));
            expensesTotal.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage verifyClickedExpense()
        {
            var verifyClickedExpense = GaugeSupport.Driver.FindElement(By.Id("expense_description"));
            verifyClickedExpense.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage verifyExpenseDescription()
        {
            var verifyExpenseDescription = GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section[1]/h2"));
            verifyExpenseDescription.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage historyMessage()
        {
            var historyMessage = GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section[2]/h2"));
            historyMessage.Text.Should().Contain(_text);
            return this;
        }
        
        public ResultsPage checkStudent2InList()
        {
            var checkStudent2InList = GaugeSupport.Driver.FindElement(By.Id("paymentrequest_who_1"));
            checkStudent2InList.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage checkStudent3InList()
        {
            var checkStudent3InList = GaugeSupport.Driver.FindElement(By.Id("paymentrequest_who_2"));
            checkStudent3InList.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage checkStudent2PaymentStatus()
        {
            var checkStudent2PaymentStatus = GaugeSupport.Driver.FindElement(By.Id("paymentrequest_paid_1"));
            checkStudent2PaymentStatus.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage checkStudent3PaymentStatus()
        {
            var checkStudent3PaymentStatus = GaugeSupport.Driver.FindElement(By.Id("paymentrequest_paid_2"));
            checkStudent3PaymentStatus.Text.Should().Contain(_text);
            return this;
        }

        public ResultsPage verifyTotalPaymentsRequested()
        {
            var verifyTotalPaymentsRequested = GaugeSupport.Driver.FindElement(By.Id("total_paymentrequests"));
            verifyTotalPaymentsRequested.Text.Should().Contain(_text);
            return this;
        }


        public ResultsPage IsCorrectExpenseDescription(string expense)
        {
            GaugeSupport.Driver.FindElement(By.Id("expense_description")).Text.Should().Be(expense);
            return this;
        }

        public ResultsPage RequestSentToStudent(string name, string amount, string IsPaid)
        {
            GaugeSupport.Driver.FindElement(By.Id("paymentrequest_who_3")).Text.Should().Be(name);
            GaugeSupport.Driver.FindElement(By.Id("paymentrequest_paid_3")).Text.Should().Be(IsPaid);
            GaugeSupport.Driver.FindElement(By.Id("paymentrequest_amount_3")).Text.Should().Be(amount);
            return this;
        }

        public ResultsPage IsPeopleWhoOweMe(string title)
        {
            GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section/h2")).Text.Should().Be(title);
            return this;
        }

         public ResultsPage IsAddedToPaymentRequestSent(string name, string amount, string expense)
        {
            GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section/table/tbody/tr[3]/td[1]")).Text.Should().Be(expense);
            GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section/table/tbody/tr[3]/td[2]")).Text.Should().Be(name);
            GaugeSupport.Driver.FindElement(By.XPath("/html/body/main/section/table/tbody/tr[3]/td[4]")).Text.Should().Be(amount);
            return this;
        }

        public ResultsPage verifyPayedExpense()
        {
            var verifyPayedExpense = GaugeSupport.Driver.FindElement(By.Id("payment_request_8"));
            verifyPayedExpense.Text.Should().Contain(_text);
            return this;
        }

    }
}