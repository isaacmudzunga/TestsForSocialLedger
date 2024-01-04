using System.Runtime.Intrinsics.X86;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using Scenarios.Pages;

namespace Scenarios.Steps
{
    public class PaymentJourney
    {
        // private readonly LogInPage _loginPage = new LogInPage();
        private readonly PaymentPage paymentPage = new PaymentPage();

        [Step("User lands on a page")]
        public void UserLandsOnAPage() => paymentPage.NavigateToHomePage();

        [Step("User enters their email <student3@wethinkcode.co.za> to login")]
        public void UserEntersTheirEmailToLogin(string email) => paymentPage.logIn(email);

        [Step("User anvigates to PaymentRequestReceived tab")]
        public void UserAnvigatesToPaymentrequestreceivedTab() =>paymentPage.navigateTopRRTab();

        [Step("Student clicks pay for a lunch expense")]
        public void StudentClicksPayForALunchExpense() => paymentPage.clickPayForExpense();

        [Step("User navigates back to expenses page")]
        public void UserNavigatesBackToExpensesPage() => paymentPage.navigateBackToExpansePage();

        [Step("Verify that the expense that was paid for is added on the expense page <Lunch>")]
        public void VerifyThatTheExpenseThatWasPaidForIsAddedOnTheExpensePage(string expense)
        {
            var resultsPage = new ResultsPage(expense);
            resultsPage.verifyPayedExpense();
        }
    }
}