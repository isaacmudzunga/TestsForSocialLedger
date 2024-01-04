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
    public class PaymentRequests
    {
        private object result;
        private PaymentRequestDTO paymentRequestDTO;
        private List<PaymentRequestDTO> listPaymentRequestDTO;
        private readonly PaymentRequestsApi _payment = new PaymentRequestsApi(StepsHelper.BasePath);


        [Step("Create request for expenseId <expenseId> fromPersonId <fromPersonId> toPersonId <toPersonId> amount <amount> to be paid by <date>")]
        public void CreateRequestForExpenseidFrompersonidTopersonidAmountToBePaidBy(int expenseId ,int fromPersonId ,int toPersonId ,int amount ,string date)
        {
            NewPaymentRequestDTO newPaymentRequestDTO = new NewPaymentRequestDTO(
                amount : amount,
                expenseId : expenseId,
                fromPersonId : fromPersonId,
                toPersonId :toPersonId,
                date : date
            );

            paymentRequestDTO = _payment.CreatePaymentRequest(newPaymentRequestDTO);
            
        }


        [Step("Post request for expenseId <expenseId> fromPersonId <fromPersonId> toPersonId <toPersonId> amount <amount> to be paid by <date>")]
        public void PostRequestForExpenseidFrompersonidTopersonidAmountToBePaidBy(int expenseId ,int fromPersonId ,int toPersonId ,int amount ,string date)
        
        {
            NewPaymentRequestDTO newPaymentRequestDTO = new NewPaymentRequestDTO(
                amount : amount,
                expenseId : expenseId,
                fromPersonId : fromPersonId,
                toPersonId :toPersonId,
                date : date
            );

            Action action = () =>  _payment.CreatePaymentRequest(newPaymentRequestDTO);
            result = action.Should().Throw<ApiException>().Which;
        
        }

        [Step("Verify status code <Http>")]
        public void VerifyStatusCode(string Http)
        {
            result.ToString().Should().Contain(Http);
        }

        [Step("Verify error message <Message>")]
        public void VerifyErrorMessage(string Message)
        {
          result.ToString().Should().Contain(Message);
        }


        [Step("Check that the request was created")]
        public void CheckThatTheRequestWasCreated()
        {
            paymentRequestDTO.Should().NotBeNull();
        }
     

        [Step("Get all payment requests")]
        public void GetAllPaymentRequests()
        {
            listPaymentRequestDTO = _payment.FindAllPaymentRequests();
        }

        [Step("Check the payment request list is not empty")]
        public void _CheckThePaymentRequestListInNot()
        { 
           listPaymentRequestDTO.Should().NotBeNull();
        }


        [Step("Get payments request received by person with Id <Id>")]
        public void GetPaymentsRequestReceivedByPersonWithId(int Id)
        {
            listPaymentRequestDTO = _payment.FindPaymentRequestsReceived(Id);
        }

        [Step("Retrieve payments request received by person with Id <Id>")]
        public void RetrievePaymentsRequestReceivedByPersonWithId(int Id)
        {
            Action action = () =>  _payment.FindPaymentRequestsReceived(Id);
            result = action.Should().Throw<ApiException>().Which;
        }


        [Step("Verify that the list is empty")]
        public void VerifyThatTheListIsEmpty()
        {
            listPaymentRequestDTO.Should().BeEmpty();
        }


        [Step("Get payments request sent by person with Id <Id>")]
        public void GetPaymentsRequestSentByPersonWithId(int Id)
        {
            listPaymentRequestDTO = _payment.FindPaymentRequestsSent(Id);
        }

        [Step("Retrieve payments request sent by person with Id <Id>")]
        public void RetrievePaymentsRequestSentByPersonWithId(int Id)
        {
            Action action = () =>  _payment.FindPaymentRequestsSent(Id);
            result = action.Should().Throw<ApiException>().Which;
        }

    }

}

