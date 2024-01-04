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
    public class PaymentRequests2
    {
        
        private PaymentRequestDTO _verifyPaymentRequest;
        private Action _verifyPayReq;
        
        public PaymentRequestDTO VerifyPayment
        {
            get { return _verifyPaymentRequest; }
            set { _verifyPaymentRequest = value; }
        }
        
        public Action VerifyPaymentRequest
        {
            get { return _verifyPayReq; }
            set { _verifyPayReq = value; }
        }

        private readonly PaymentRequestsApi _paymentsRequestsApi = new PaymentRequestsApi(StepsHelper.BasePath);

        
        [Step("Verify that id, expenseId, as well as fromPersonId exists in the response body")]
        public void GetPaymentRequestByIdSucessfully()
        {
            //Act
            _verifyPaymentRequest = _paymentsRequestsApi.GetPaymentRequestById(2);

            //Assert
            _verifyPaymentRequest.Should().NotBeNull();
            _verifyPaymentRequest.ToString().Contains("*id: *");
            _verifyPaymentRequest.ToString().Contains("*expenseId: *");
            _verifyPaymentRequest.ToString().Contains("*fromPersonId: *");
      
            
        }
        
        
        [Step("Verify that toPersonId, date, amount, as well as isPaid exists in the response body")]
        public void GetPaymentRequestByIdSucessfully2()
        {

            //Assert
            _verifyPaymentRequest.Should().NotBeNull();
            _verifyPaymentRequest.ToString().Contains("*date: *");
            _verifyPaymentRequest.ToString().Contains("*amount: *");
            _verifyPaymentRequest.ToString().Contains("*isPaid: *");
            _verifyPaymentRequest.ToString().Contains("*toPersonId: *");
            

      
            
        }
        [Step("Verify that the response body contains substring ID must be greater than 0")]
        public void  GetPaymentRequestByIdLessThan0()
        {
            //Act
            _verifyPayReq = () =>  _paymentsRequestsApi.GetPaymentRequestById(0);;

            //Assert
            _verifyPayReq.Should().Throw<ApiException>()
                .WithMessage("*ID must be greater than*");
            _verifyPayReq.Should().Throw<ApiException>().WithMessage("*0*");
        }
        
        
        [Step("Verify that the list is the response body is not null")]
        public void GetPaymentRequestByIdLessThan0ErrorMessage()
        {
           
            //Assert
          
            _verifyPayReq.ToString().Length.Should().BeGreaterThan(10);
            
        }
        
        [Step("Check that the HttpResponse is 404(PaymentRequest not found)")]
        public void  GetPaymentRequestThatDoesNotExist404()
        {
            //Act
            _verifyPayReq = () =>  _paymentsRequestsApi.GetPaymentRequestById(56);

            //Assert
            _verifyPayReq.Should().Throw<ApiException>()
                .WithMessage("*404*");
            _verifyPayReq.Should().Throw<ApiException>().
                WithMessage("*https://javalin.io/documentation#notfoundresponse*");
        }
        
        
        [Step("Check that the response body contains substring Payment Request not found:")]
        public void GetPaymentRequestThatDoesNotExistErrorMessage()
        {
           
            //Assert
            _verifyPayReq.Should().Throw<ApiException>().
                WithMessage("*Payment Request not found: 56*");
            // _verifyPaymentRequest.Should().NotBeNull();
            _verifyPayReq.ToString().Length.Should().BeGreaterThan(12);
            
        }
        
        [Step("Verify that the response body contains sub string Payment Request has already been paid: 1")]
        public void  RecallPaymentRequestThatHasAlreadyBeenPaidError()
        {
            //Act
            _verifyPayReq = () =>  _paymentsRequestsApi.RecallUnpaidPaymentRequest(1);

            //Assert
            _verifyPayReq.Should().Throw<ApiException>()
                .WithMessage("*Payment Request has already been paid:*");
            _verifyPayReq.Should().Throw<ApiException>().
                WithMessage("*1*");
        }
        
        
        [Step("Check that content length is greater than 5")]
        public void RecallPaymentRequestThatHasAlreadyBeenPaidErrorMessage()
        {
            //Assert
            _verifyPayReq.ToString().Length.Should().BeGreaterThan(5);
            
        }
        
        [Step("Check that the response body contains substring ID must be greater than 0")]
        public void  RecallPaymentRequestWithIdLessThan0()
        {
            //Act
            _verifyPayReq = () =>  _paymentsRequestsApi.RecallUnpaidPaymentRequest(-2);

            //Assert
            _verifyPayReq.Should().Throw<ApiException>()
                .WithMessage("*ID must be greater than 0*");
            _verifyPayReq.Should().Throw<ApiException>().
                WithMessage("*-2*");
        }
        
        
        [Step("Check that the string length is less than 10")]
        public void RecallPaymentRequestWithIdLessThan0ErrorMessage()
        {
            //Assert
            _verifyPayReq.ToString().Length.Should().BeGreaterThan(11);
            
        }
        
        [Step("Verify that the response body contains sub string Payment Request not found: 5")]
        public void  RecallInvalidPaymentRequest()
        {
            //Act
            _verifyPayReq = () =>  _paymentsRequestsApi.RecallUnpaidPaymentRequest(5);

            //Assert
            _verifyPayReq.Should().Throw<ApiException>()
                .WithMessage("*Payment Request not found:*");
            _verifyPayReq.Should().Throw<ApiException>().
                WithMessage("*5*");
        }
        
    
    }
}