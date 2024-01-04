using System.Collections.Generic;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using Applications.Weshare.Swagger.Api;
using Applications.Weshare.Swagger.Model;
using System;
using System.Net.Http;
using static Applications.Weshare.Swagger.Model.ExpenseDTO;
using Applications.Weshare.Swagger.Client;

namespace Applications.Weshare.Steps
{
    public class Expenses
    {
        private object result;
        private ExpenseDTO expenseDTO;
        private List<ExpenseDTO> listExpenseDTO;
        private readonly ExpensesApi _expense = new ExpensesApi(StepsHelper.BasePath);

         [Step("Get the list of all expenses")]
        public void GetTheListOfAllExpenses()
        {
            listExpenseDTO = _expense.FindAllExpenses();
        }

        [Step("Verify that the list is not null")]
        public void VerifyThatTheListIsNotNull()
        {
            listExpenseDTO.Should().NotBeNull();
        }

        [Step("Get expense <Id> in the list")]
        public void GetExpenseInTheList(int Id)
        {
            expenseDTO = listExpenseDTO[0];
        }


        [Step("Verify that it is <expense> expense of <amount>")]
        public void VerifyThatItIsExpenseOf(string expense ,int amount)
        {
            expenseDTO.Description.Should().Be(expense);
            expenseDTO.Amount.Should().Be(amount);
        }


        [Step("Get the list for personId <Id>")]
        public void GetTheListForPersonid(int Id)
        {
            listExpenseDTO = _expense.FindExpensesByPerson(Id);
        }

        [Step("Verify that is of personId <Id>")]
        public void VerifyThatIsOfPersonid(int Id)
        {
            expenseDTO.PersonId.Should().Be(Id);
        }

       [Step("Retrieve the list for personId <Id>")]
        public void RetrieveTheListForPersonid(int Id)
        {
            Action action = () => _expense.FindExpensesByPerson(Id);
            result = action.Should().Throw<ApiException>().Which;
        }

        [Step("Check status code <Code>")]
        public void CheckStatusCode(string Code)
        {
         result.ToString().Should().Contain(Code);
        }

        [Step("Check error message <Message>")]
        public void CheckErrorMessage(string Message)
        {
            result.ToString().Should().Contain(Message);
        }
        

        [Step("Get expense with Id <Id>")]
        public void GetExpenseWithId(int Id)
        {
            expenseDTO = _expense.FindExpenseById(Id);
        }

         [Step("Retrieve expense with Id <Id>")]
        public void RetrieveExpenseWithId(int Id)
        {
            Action action = () => _expense.FindExpenseById(Id);
            result = action.Should().Throw<ApiException>().Which;
        }


        [Step("Create expense for <description> by person <Id> of <amount> on <date>")]
        public void CreateExpenseForByPersonOfOn(string description ,int Id ,int amount ,string date)
        {
            NewExpenseDTO newExpense = new NewExpenseDTO(
                amount : amount,
                personId : Id,
                date : date,
                description : description
            );
            expenseDTO = _expense.CreateExpense(newExpense);
        }

        [Step("Verify that it is <description> expense of <amount> by person <Id> was added")]
        public void VerifyThatItIsExpenseOfByPersonWasAdded(string description ,int amount, int Id)
        {
            expenseDTO.Description.Should().Be(description);
            expenseDTO.Amount.Should().Be(amount);
            expenseDTO.PersonId.Should().Be(Id);
        }

        [Step("Post expense for <description> by person <Id> of <amount> on <date>")]
        public void PostExpenseForByPersonOfOn(string description ,int Id ,int amount ,string date)
        {
         NewExpenseDTO newExpense = new NewExpenseDTO(
                amount : amount,
                personId : Id,
                date : date,
                description : description
            );
            Action action = () =>  _expense.CreateExpense(newExpense);
            result = action.Should().Throw<ApiException>().Which;
        }

    }

}