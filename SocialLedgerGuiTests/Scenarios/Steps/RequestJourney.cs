using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using Scenarios.Pages;

namespace Scenarios.Steps
{
    public class RequestJourney
    {
        private readonly LogInPage _loginPage = new LogInPage();
        private readonly RequestPage requestPage = new RequestPage();
        private ResultsPage resultsPage;


        [Step("Open login page")]
        public void OpenHomePage() => requestPage.Open();
    

       [Step("Login as user <email>")]
        public void LoginAsUser(string email)
        {
            resultsPage = _loginPage.LogIn(email);
        }

        [Step("Open expense Airtime")]
        public void OpenExpenseAirtime()
        {
            resultsPage = requestPage.OpenExpense();
        }

        [Step("Verify that expense description is <Expense>")]
        public void VerifyThatExpenseDescriptionIs(string Expense)
        {
            resultsPage.IsCorrectExpenseDescription(Expense);
        }

        [Step("Request <amount> for Airtime from <email> pay by <date>")]
        public void RequestForAirtimeFromPayBy(string email ,string date ,string amount)
        {
            resultsPage = requestPage.CreateExpenseRequest(email,date,amount);
        }

        [Step("Verify that request of <amount> was sent to <name> and is paid <IsPaid>")]
        public void VerifyThatRequestOfWasSentToAndIsPaid(string amount ,string name ,string IsPaid)
        {
            resultsPage.RequestSentToStudent(name,amount,IsPaid);
        }

        [Step("Open payment requests sent")]
        public void OpenPaymentRequestsSent()
        {
            resultsPage = requestPage.OpenRequestSents();
        }

        [Step("Check if it is <title> section")]
        public void CheckIfItIsSection(string section)
        {
            resultsPage.IsPeopleWhoOweMe(section);
        }

        [Step("Verify that <expense> request of <amount> sent to <name> was added to the list")]
        public void VerifyThatRequestOfSentToWasAddedToTheList(string name ,string amount ,string expense)
        {
            resultsPage.IsAddedToPaymentRequestSent(name,amount,expense);
        }

    }
}
