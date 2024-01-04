# Payments Test Plan


## Pay a payment request with a valid expenseId but invalid payingPersonId
* Check that the HttpResponse is code 404(Not Found)
* Check that the Error message contains string person not found

## Pay a payment request with a valid expenseId, valid payingPersonId but invalid paymentRequestId
* Verify that the HttpResponse is 404(Not Found)
* Verify that the Error message contains string Payment Request not found

## Pay a payment request with a valid paymentRequestId, valid payingPersonId but invalid expenseId
* Verify that the HttpResponse is 404
* Verify that the Error message contains string Expense not found

## Pay a payment request with valid information, but has already been paid
* Verify that the Error message contains string Payment Request has already been paid

## Pay a payment request succesfully with valid information
* Verify that id , expenseId as well as date is not null
* Verify that PaymentRequestId & amount is not null
* Verify that PayingPersonId is not null

## Find all payments made by a user with an ID equals to or less than 0
* Verify that message contains string ID must be greater than 0

## Find all payments made by a non-existent user 
* Check that the HttpResponse is 404
* Verify that the Error message contains substring Person not found: 100

## Find all payments made by an existing user with valid information
* Verify that response body contains substrings id, expenseId, paymentRequestId, payingPersonId as well as date

## Find all payments made by an existing user with valid information who hasn't made any payments
* Verify the length of the array to be 0

 