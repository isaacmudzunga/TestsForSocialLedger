using System.Runtime.Intrinsics.X86;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using Scenarios.Pages;

namespace Scenarios.Steps
{
    public class LogInJourney
    {
        private readonly LogInPage _loginPage = new LogInPage();

        // Login page
        [Step("User open a web page")]
        public void UserOpenAWebPage() => _loginPage.Open();

        [Step("Verify the webpage title is <WeShare>")]
        public void VerifyThePageTitleIs(string title)
        {
            var resultsPage = new ResultsPage(title);
            resultsPage.isCorrectTitle();
        }

        [Step("User should see this message <You are not logged in!> to show that they are not logged in")]
        public void UserShouldSeeThisMessageToShowThatTheyAreNotLoggedIn(string message)
        {
            var resultsPage = new ResultsPage(message);
            resultsPage.alertMessage();
        }

        [Step("User enter their email <student4@wethinkcode.co.za> to log in")]
        public void UserEnterTheirEmailToLogIn(string email) => _loginPage.enterLogInEmail(email);
        

        [Step("User should click a login button to log in")]
        public void UserShouldClickALoginButtonToLogIn() => _loginPage.clickLogInButton();

        // Expanses Page
        [Step("Page should display user email <student4@wethinkcode.co.za>")]
        public void PageShouldDisplayUserEmail(string userEmail)
        {
            var resultsPage = new ResultsPage(userEmail);
            resultsPage.displayUserEmail();
        }

        [Step("User verify the expenses page by a header <My Expenses>")]
        public void UserVerifyTheExpensesPageByAHeader(string header)
        {
            var resultsPage = new ResultsPage(header);
            resultsPage.pagePageHeader();
        }

        [Step("Expenses page must be empty, displays <You don't have any expenses!> message to the user")]
        public void ExpensesPageMustBeEmptyDisplaysMessageToTheUser(string message)
        {
            var resultsPage = new ResultsPage(message);
            resultsPage.alertPerson();
        }

        [Step("User should navigate to Payment Request Sent page by clicking on a Payment Request Sent tab")]
        public void UserShouldNavigateToPaymentRequestSentPageByClickingOnAPaymentRequestSentTab() => _loginPage.clickPaymentRequestSentTab();

        // Paymentrquests_sent page
        [Step("Page still display user email <student4@wethinkcode.co.za>")]
        public void PageStillDisplayUserEmail(string userEmail)
        {
            var resultsPage = new ResultsPage(userEmail);
            resultsPage.displayUserEmail();
        }

        [Step("User verify the Paymentrquests_sent page page by a header <People that owe me>")]
        public void UserVerifyThePaymentrquests_SentPagePageByAHeader(string reminderMessage)
        {
            var resultsPage = new ResultsPage(reminderMessage);
            resultsPage.pagePageHeader();
        }

        [Step("Paymentrquests_sent page page must be empty, displays <Nobody owes you anything!> message to the user")]
        public void Paymentrquests_SentPagePageMustBeEmptyDisplaysMessageToTheUser(string alertMessage)
        {
            var resultsPage = new ResultsPage(alertMessage);
            resultsPage.requestSentAlert();
        }

        [Step("User should navigate to Paymentrquests_received page by clicking on a Payment Request Received tab")]
        public void UserShouldNavigateToPaymentrquests_ReceivedPageByClickingOnAPaymentRequestReceivedTab() => _loginPage.clickPaymentRequestReceivedTab();

        // Paymentrquests_received page
        [Step("display user email <student4@wethinkcode.co.za>")]
        public void DisplayUserEmail(string userEmail)
        {
            var resultsPage = new ResultsPage(userEmail);
            resultsPage.displayUserEmail();
        }

        [Step("User verify the Paymentrquests_received page page by a header <People that you owe>")]
        public void UserVerifyThePaymentrquests_ReceivedPagePageByAHeader(string reminderMessage)
        {
            var resultsPage = new ResultsPage(reminderMessage);
            resultsPage.pagePageHeader();
        }

        [Step("Paymentrquests_received page page must be empty, displays <You don't owe anyone anything!> message to the user")]
        public void Paymentrquests_ReceivedPagePageMustBeEmptyDisplaysMessageToTheUser(string alert)
        {
            var resultsPage = new ResultsPage(alert);
            resultsPage.requestsReceivedAlert();
        }

        [Step("User should click logout tab")]
        public void UserShouldClickLogoutTab() => _loginPage.clickLogOutTab();
    }
}