using System.Runtime.Intrinsics.X86;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using Scenarios.Pages;

namespace Scenarios.Steps
{
    public class ViewPaymentMadeJourney
    {
        private readonly ViewPaymentMadePage _viewPaymentMadePage = new ViewPaymentMadePage();
        private readonly LogInPage _loginPage = new LogInPage();

        // Login to Weshare
        [Step("User open a login page")]
        public void UserOpenALoginPage() => _viewPaymentMadePage.Open();

        [Step("Verify the page title is <WeShare>")]
        public void VerifyThePageTitleIs(string title)
        {
            var resultsPage = new ResultsPage(title);
            resultsPage.isCorrectTitle();
        }

        [Step("<You are not logged in!> message should be displayed to the user")]
        public void _MessageShouldBeDisplayedToTheUser(string alertMessage)
        {
            var resultsPage = new ResultsPage(alertMessage);
            resultsPage.alertMessage();
        }

        [Step("Student enter their email <student1@wethinkcode.co.za> to log in")]
        public void StudentEnterTheirEmailToLogIn(string email) => _loginPage.enterLogInEmail(email);

        [Step("User should click a login button")]
        public void UserShouldClickALoginButton() => _loginPage.clickLogInButton();

        // Verify Expenses Page
        [Step("Verify the page header <My Expenses>")]
        public void VerifyThePageHeader(string header)
        {
            var resultsPage = new ResultsPage(header);
            resultsPage.expenseViewHeader();
        }
        [Step("Verify the total expenses displayed is <ZAR 300.00>")]
        public void VerifyTheTotalExpensesDisplayedIs(string total)
        {
            var resultsPage = new ResultsPage(total);
            resultsPage.expensesTotal();
        }

        [Step("User should click on expense Lunch")]
        public void UserShouldClickOnExpenseLunch() => _viewPaymentMadePage.clickExpense();

        // Verify Page of an Expense
        [Step("Verify that the page is displaying this message <expenseMessage>")]
        public void VerifyThatThePageIsDisplayingThisMessage(string expenseMessage)
        {
            var resultsPage = new ResultsPage(expenseMessage);
            resultsPage.verifyExpenseDescription();
        }

        [Step("Verify that it the clicked expense that is rendered to a new page <Lunch>")]
        public void VerifyThatItTheClickedExpenseThatIsRenderedToANewPage(string expense)
        {
            var resultsPage = new ResultsPage(expense);
            resultsPage.verifyClickedExpense();
        }

        [Step("Verify history message <Previous Payment Requests for this expense>")]
        public void VerifyHistoryMessage(string historyMessage)
        {
            var resultsPage = new ResultsPage(historyMessage);
            resultsPage.historyMessage();
        }

        [Step("Verify that <student2> is in the list of previous payments")]
        public void VerifyThatIsInTheListOfPreviousPayments(string student)
        {
            var resultsPage = new ResultsPage(student);
            resultsPage.checkStudent2InList();
        }

        [Step("Verify if Student2 paid <Yes>")]
        public void VerifyIfStudent2Paid(string paymentstatus)
        {
            var resultsPage = new ResultsPage(paymentstatus);
            resultsPage.checkStudent2PaymentStatus();
        }

        [Step("Verify that <student3> is in the list of previous payments as well")]
        public void VerifyThatIsInTheListOfPreviousPaymentsAsWell(string student)
        {
            var resultsPage = new ResultsPage(student);
            resultsPage.checkStudent3InList();
        }

        [Step("Verify if student3 paid <No>")]
        public void VerifyIfStudent3Paid(string paymentstatus)
        {
            var resultsPage = new ResultsPage(paymentstatus);
            resultsPage.checkStudent3PaymentStatus();
        }

        [Step("Verify the total amount of payments requested is <ZAR 200.00>")]
        public void VerifyTheTotalAmountOfPaymentsRequestedIs(string checkTotal)
        {
            var resultsPage = new ResultsPage(checkTotal);
            resultsPage.verifyTotalPaymentsRequested();
        }
    }
}