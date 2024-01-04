using FluentAssertions;
using NuGet;
using OpenQA.Selenium;
using static Scenarios.GaugeSupport;

namespace Scenarios.Pages
{
    public class Expense
    {
        private const string Url = "http://localhost:5050";
        
       

        
        public  IWebDriver Driver = GaugeSupport.Driver;

        private IWebElement Email => Driver.FindElement(By.Id("email"));
        
        private IWebElement SubmitButton => Driver.FindElement(By.Id("submit"));


        private IWebElement Description => Driver.FindElement(By.Id("description"));
        
        private IWebElement Date => Driver.FindElement(By.Id("date"));
        
        private IWebElement Amount => Driver.FindElement(By.Id("amount"));
        
        private IWebElement CreateExpButton => Driver.FindElement(By.Id("submit"));
        
        
        public void NavigateToHomePage()
        {
            // Navigate to the URL of the nopCommerce landing page
            Driver.Navigate().GoToUrl(Url);
        }

       
        public void VerifyHomePage()
        {

            IWebElement LoginButton = Driver.FindElement(By.CssSelector("#submit")); 

            // Act
            var buttonText = LoginButton.GetAttribute("value");
            
            //Assert
            LoginButton.Should().NotBeNull();
            buttonText.Should().Be("Login");
         

        }
        
        public void LoginOnHomePage()
        {

            IWebElement submitButton = Driver.FindElement(By.CssSelector("#submit")); 

            // Act
            var altText = submitButton.GetAttribute("value");
            
            
            submitButton.Should().NotBeNull();
            altText.Should().Be("Login");
            
        
            Email.SendKeys("student1@wethinkcode.co.za");
            SubmitButton.Click();
            
            
            Driver.FindElement(By.CssSelector("#user")).Text.Contains("student1@wethinkcode.co.za");
            
        }
        

         public void VerifyExpensePage()
        {

            IWebElement AddExpButton = Driver.FindElement(By.CssSelector("#add_expense")); 

            // Act
            var buttonText = AddExpButton.GetAttribute("id");
            
            //Assert
            AddExpButton.Should().NotBeNull();
            buttonText.Should().Be("add_expense");
         

        }

         public void CreateNewExp()
        {

            IWebElement AddExpButton = Driver.FindElement(By.CssSelector("#add_expense")); 
            AddExpButton.Click();
            
            IWebElement Description = Driver.FindElement(By.Id("description"));
        
            IWebElement Date = Driver.FindElement(By.Id("date"));
        
            IWebElement Amount = Driver.FindElement(By.Id("amount"));
        
            IWebElement CreateExpButton = Driver.FindElement(By.Id("submit"));

            
            Description.SendKeys("Bevv");
            Date.SendKeys("04/12/2023");
            Amount.SendKeys("500");
            CreateExpButton.Click();
     

        }
        

         public void VerifyNewExpSuccesfully()
         {
             IWebElement ExpensesPage = Driver.FindElement(By.CssSelector(".expenseList > table:nth-child(3) > tbody:nth-child(2)")); 

             // Act
             var buttonText = ExpensesPage.Text;
            
             //Assert
             ExpensesPage.Should().NotBeNull();
             buttonText.Should().Contain("Bevv");
             
         }
    }
}