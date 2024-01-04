# PaymentRequest2 Test Plan


## Get an existing payment request by using a valid ID
* Verify that id, expenseId, as well as fromPersonId exists in the response body
* Verify that toPersonId, date, amount, as well as isPaid exists in the response body

## Get a payment request by using an invalid ID that is equals to or less than 0
* Verify that the response body contains substring ID must be greater than 0
* Verify that the list is the response body is not null

## Get a payment request that does not exist
* Check that the HttpResponse is 404(PaymentRequest not found)
* Check that the response body contains substring Payment Request not found:

## Recall a paid payment request with an existing ID
* Verify that the response body contains sub string Payment Request has already been paid: 1
* Check that content length is greater than 5

## Recall a payment request using an invalid ID that is equals to or less than 0
* Check that the response body contains substring ID must be greater than 0
* Check that the string length is less than 10

## Recall an unpaid payment request that is non-existent
* Verify that the response body contains sub string Payment Request not found: 5


