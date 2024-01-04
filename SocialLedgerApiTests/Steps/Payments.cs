using System.Collections.Generic;
using Applications.Weshare.Swagger.Api;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using System;
using Applications.Weshare.Swagger.Model;



namespace Applications.Weshare.Steps
{
    public class Payments
    {
        private Action _verifyPayment;
        private List<PaymentDTO> _listOfPayments;

        public Action VerifyPayment
        {
            get { return _verifyPayment; }
            set { _verifyPayment = value; }
        }

        public List<PaymentDTO> PaymentsList
        {
            get { return _listOfPayments; }
            set { _listOfPayments = value; }
        }

        private readonly PaymentsApi _paymentsApi = new PaymentsApi(StepsHelper.BasePath);

        [Step("Check that the HttpResponse is code 404(Not Found)")]
        public void APaymentReqWithInvalidPayingPersonIdError404()
        {
            NewPaymentDTO newPaymentDtoO = new NewPaymentDTO(2, 2, 8);

            //Act
            _verifyPayment = () => _paymentsApi.PayPaymentRequest(newPaymentDtoO);

            //Assert
            _verifyPayment.Should().Throw<Applications.Weshare.Swagger.Client.ApiException>().WithMessage("*404*");

        }

        [Step("Check that the Error message contains string person not found")]
        public void APaymentReqWithInvalidPayingPersonIdErrorMessage()
        {
            _verifyPayment.Should().Throw<Applications.Weshare.Swagger.Client.ApiException>()
                .WithMessage("*Person not found: 8*");

        }

        [Step("Verify that the HttpResponse is 404(Not Found)")]
        public void APaymentReqWithInvalidPaymentReqIdError404()
        {
            NewPaymentDTO newPaymentDtoO = new NewPaymentDTO(2, 9, 2);

            //Act
            _verifyPayment = () => _paymentsApi.PayPaymentRequest(newPaymentDtoO);

            //Assert
            _verifyPayment.Should().Throw<Applications.Weshare.Swagger.Client.ApiException>().WithMessage("*404*");

        }

        [Step("Verify that the Error message contains string Payment Request not found")]
        public void APaymentReqWithInvalidPaymentReqIdErrorMessage()
        {
            _verifyPayment.Should().Throw<Applications.Weshare.Swagger.Client.ApiException>()
                .WithMessage("*Payment Request not found: 9*");

        }

        [Step("Verify that the HttpResponse is 404")]
        public void APaymentReqWithInvalidExpIdError404()
        {
            NewPaymentDTO newPaymentDtoO = new NewPaymentDTO(8, 2, 2);

            //Act
            _verifyPayment = () => _paymentsApi.PayPaymentRequest(newPaymentDtoO);

            //Assert
            _verifyPayment.Should().Throw<Applications.Weshare.Swagger.Client.ApiException>().WithMessage("*404*");

        }

        [Step("Verify that the Error message contains string Expense not found")]
        public void APaymentReqWithInvalidExpIdErrorMessage()
        {
            _verifyPayment.Should().Throw<Applications.Weshare.Swagger.Client.ApiException>()
                .WithMessage("*Expense not found: 8*");

        }

        [Step("Verify that the Error message contains string Payment Request has already been paid")]
        public void APaymentReqAlreadyPaidErrorMessage()
        {
            NewPaymentDTO newPaymentDtoO = new NewPaymentDTO(1, 1, 1);

            //Act
            _verifyPayment = () => _paymentsApi.PayPaymentRequest(newPaymentDtoO);

            //Assert
            _verifyPayment.Should().Throw<Applications.Weshare.Swagger.Client.ApiException>()
                .WithMessage("*Payment Request has already been paid: 1*");

        }

        [Step("Verify that id , expenseId as well as date is not null")]
        public void ASuccessfulPayment()
        {
            NewPaymentDTO newPaymentDtoO = new NewPaymentDTO(2, 2, 3);

            //Act
            _verifyPayment = () => _paymentsApi.PayPaymentRequest(newPaymentDtoO);

            //Assert
            _verifyPayment.Should().NotBeNull();
            _verifyPayment.ToString().Contains("*id: 2*");
            _verifyPayment.ToString().Contains("*expenseId: 6*");
            _verifyPayment.ToString().Contains("*date: 04/12/2023*");

        }

        [Step("Verify that PaymentRequestId & amount is not null")]
        public void ASuccessfulPaymentMessage()
        {
            _verifyPayment.Should().NotBeNull();
            _verifyPayment.ToString().Contains("*paymentRequestId: *");

        }


        [Step("Verify that PayingPersonId is not null")]
        public void ASuccessfulPaymentMessageTwo()
        {
            _verifyPayment.Should().NotBeNull();
            _verifyPayment.ToString().Contains("*payingPersonId: *");
        }

        [Step("Verify that message contains string ID must be greater than 0")]
        public void VerifyThatMessageContainsStringIdMustBeGreaterThan0()
        {
            //Act
            _verifyPayment = () => _paymentsApi.FindPaymentsMadeByPerson(0);

            //Assert
            _verifyPayment.Should().Throw<Applications.Weshare.Swagger.Client.ApiException>()
                .WithMessage("*ID must be greater than*");
            _verifyPayment.Should().Throw<Applications.Weshare.Swagger.Client.ApiException>().WithMessage("*0*");
        }

        [Step("Check that the HttpResponse is 404")]
        public void FindingPaymentsByNonExistentUsers()
        {
            //Act
            _verifyPayment = () => _paymentsApi.FindPaymentsMadeByPerson(100);

            //Assert
            _verifyPayment.Should().Throw<Applications.Weshare.Swagger.Client.ApiException>().WithMessage("*404*");
        }

        [Step("Verify that the Error message contains substring Person not found: 100")]
        public void FindingPaymentsByNonExistentUsersErrorMessage()
        {
            //Assert
            _verifyPayment.Should().Throw<Applications.Weshare.Swagger.Client.ApiException>()
                .WithMessage("*Person not found: 100*");

        }


        [Step(
            "Verify that response body contains substrings id, expenseId, paymentRequestId, payingPersonId as well as date")]
        public void FindingPaymentsSuccessfully()
        {
            //Act
            var verifyPayment = _paymentsApi.FindPaymentsMadeByPerson(2);

            //Assert
            verifyPayment.Should().NotBeNull();
            verifyPayment.ToString().Contains("*payingPersonId: *");
            verifyPayment.ToString().Contains("*amount: *");
            verifyPayment.ToString().Contains("*expenseId: *");
            verifyPayment.ToString().Contains("*paymentRequestId: *");
            verifyPayment.ToString().Contains("*payingPersonId: *");
            verifyPayment.ToString().Contains("*date: *");

        }

        [Step("Verify the length of the array to be 0")]
        public void FindingPaymentsSuccessfully2()
        {
            //Act
            var verifyPayment = _paymentsApi.FindPaymentsMadeByPerson(1);

            //Assert
            verifyPayment.Count.Should().Be(0);

        }
    }

}