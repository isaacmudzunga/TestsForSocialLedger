# Payment Requests

## Create a new payment request

* Create request for expenseId "2" fromPersonId "1" toPersonId "3" amount "0" to be paid by "19/12/2023"
* Check that the request was created


## Create a new payment request for more than expense amount

* Post request for expenseId "1" fromPersonId "1" toPersonId "3" amount "1000" to be paid by "19/12/2023"
* Verify error message "more than the expense amount"


## Find all payment requests

* Get all payment requests
* Check the payment request list is not empty

## Find payment requests received by a person

* Get payments request received by person with Id "3"
* Check the payment request list is not empty


## Find payment requests received by a person without requests received

* Get payments request received by person with Id "1"
* Verify that the list is empty


## Find payment requests sent by a person

* Get payments request sent by person with Id "1"
* Check the payment request list is not empty


## Find payment requests sent by a person without requests sent

* Get payments request sent by person with Id "3"
* Verify that the list is empty

## Create a new payment request for invalid expense

* Post request for expenseId "10" fromPersonId "1" toPersonId "3" amount "1" to be paid by "19/12/2023"
* Verify status code "404"
* Verify error message "Expense not found: 10"


## Create a new payment request for to yourself

* Post request for expenseId "1" fromPersonId "1" toPersonId "1" amount "0" to be paid by "19/12/2023"
* Verify error message "You cannot request payment from yourself"

## Find payment requests sent with invalid id

* Retrieve payments request sent by person with Id "99"
* Verify status code "404"
* Verify error message "Person not found: 99"

## Find payment requests recieved with invalid id

* Retrieve payments request received by person with Id "99"
* Verify error message "Person not found: 99"


