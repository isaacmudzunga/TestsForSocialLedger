# Expenses

## Find all expenses

* Get the list of all expenses
* Verify that the list is not null
* Get expense "1" in the list
* Verify that it is "Lunch" expense of "300"


## Find expenses for a person

* Get the list for personId "1"
* Verify that the list is not null
* Get expense "1" in the list
* Verify that is of personId "1"
* Get expense "1" in the list
* Verify that it is "Lunch" expense of "300"


## Find expenses for invalid personId

* Retrieve the list for personId "99"
* Check status code "404"
* Check error message "Person not found: 99"


## Find an expense by ID

* Get expense with Id "1"
* Verify that is of personId "1"
* Verify that it is "Lunch" expense of "300"


## Find an invalid expense

* Retrieve expense with Id "99"
* Check status code "404"
* Check error message "Expense not found: 99"


## Create a new expense for a person

* Create expense for "Dinner" by person "1" of "500" on "01/12/2023"
* Verify that it is "Dinner" expense of "500" by person "1" was added



## Create a new future expense for a person

* Post expense for "Dinner" by person "1" of "500" on "01/12/2024"
* Check error message "Expense cannot be in the future"