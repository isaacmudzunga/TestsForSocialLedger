using Gauge.CSharp.Lib.Attribute;
using Scenarios.Pages;

namespace Scenarios.Steps
{
    public class HomePageJourney
    {
        private Expense _expense = new Expense();

        [Step("Open the landing page of WeShare")]
        public void OpenHomePage()
        {
           _expense.NavigateToHomePage();

        }


        [Step("Verify that the landing page is succesfully opened")]
        public void VerifyHomePage()
        {
            _expense.VerifyHomePage();

        }
     
        
        [Step("Login with a valid email")]
        public void LogOn()
        {
            _expense.LoginOnHomePage();

        }

        [Step("Verify that the student has succesfully logged in by looking for tthe add a new expense button")]
        public void VerifyTheExpensesPage()
        {
            _expense.VerifyExpensePage();

        }

        [Step("Add a new expense")]
        public void AddANewExp()
        {
            _expense.CreateNewExp();

        }

    
        
        
        [Step("Verify that expense has successfully been captured by searching for it and it's details under the expenses list")]
        public void TestNewlyAddedExpIsAddedSuccesfully()
        {
            _expense.VerifyNewExpSuccesfully();

        }
    }
}
