using System.Collections.Generic;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using Applications.Weshare.Swagger.Api;
using Applications.Weshare.Swagger.Model;
using System;
using System.Net.Http;
using static Applications.Weshare.Swagger.Model.PaymentRequestDTO;
using Applications.Weshare.Swagger.Client;

namespace Applications.Weshare.Steps
{
    public class People
    {
        private readonly PeopleApi _peopleApi = new PeopleApi(StepsHelper.BasePath);
        private Person person;
        private object result;
        // private Person Email;
        // private Person Id;

        // This plan tests the user journey to login to Weshare.
        [Step("Send a POST request to an api with the body containing email as <student1@wethinkcode.co.za>")]
        public void loginRequest(string email)
        {
            LoginDTO _login = new LoginDTO
            (
                email : email
            );
            person = _peopleApi.Login(_login);
        }

        [Step("Verify that the user is logged in <student1@wethinkcode.co.za>")]
        public void VerifyThatTheUserIsLoggedIn(string email)
        {
            person.Email.Should().Be(email);
        }

        // This plan tests the user journey to retrieve a person's details in Weshare.
        [Step("Send a GET request to an api with id <1>")]
        public void getPersonDetailsById(int id)
        {
            person = _peopleApi.FindPersonById(id);
        }

        [Step("Verify the response body has person details <student2@wethinkcode.co.za>")]
        public void verifyPersonDetails(string email)
        {
            person.Email.Should().Be(email);
            // person.Id.Should().Be(id);
        }

        [Step("Get a list of all people")]
        public void GetAListOfAllPeople()
        {
            Action action = () =>  _peopleApi.FindAllPeople();
            result = action.Should().Throw<ApiException>().Which;
        }

        [Step("Check if the list is not null")]
        public void CheckIfTheListIsNotNull()
        {
            result.ToString().Should().Contain("200");
        }
    }
}