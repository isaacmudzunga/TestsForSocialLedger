# Weshare Login

This plan tests the user journey to login to Weshare web application for the first time.

## Login to Weshare

* User open a web page 
* Verify the webpage title is "WeShare"
* User should see this message "You are not logged in!" to show that they are not logged in
* User enter their email "student4@wethinkcode.co.za" to log in
* User should click a login button to log in

## Expenses page

* Page should display user email "student4@wethinkcode.co.za"
* User verify the expenses page by a header "My Expenses"
* Expenses page must be empty, displays "You don't have any expenses!" message to the user
* User should navigate to Payment Request Sent page by clicking on a Payment Request Sent tab

## Paymentrquests_sent page

* Page still display user email "student4@wethinkcode.co.za"
* User verify the Paymentrquests_sent page page by a header "People that owe me"
* Paymentrquests_sent page page must be empty, displays "Nobody owes you anything!" message to the user
* User should navigate to Paymentrquests_received page by clicking on a Payment Request Received tab

## Paymentrquests_received page

* display user email "student4@wethinkcode.co.za"
* User verify the Paymentrquests_received page page by a header "People that you owe"
* Paymentrquests_received page page must be empty, displays "You don't owe anyone anything!" message to the user
* User should click logout tab

## A user Create a Payment request

* Open login page
* Login as user "student1@wethinkcode.co.za"
* Open expense Airtime
* Verify that expense description is "Airtime"
* Request "student3@wethinkcode.co.za" for Airtime from "25/12/2023" pay by "1"
* Verify that request of "ZAR 1.00" was sent to "Student3" and is paid "No"
* Open payment requests sent
* Check if it is "People that owe me" section
* Verify that "Airtime" request of "ZAR 1.00" sent to "Student3" was added to the list

This plan tests the user journey for student1 to view the payment made by student3.

## Login to Weshare page

* User open a login page
* Verify the page title is "WeShare"
* "You are not logged in!" message should be displayed to the user
* User enter their email "student1@wethinkcode.co.za" to log in
* User should click a login button

## Verify Expenses Page

* Verify the page header "My Expenses"
* User should click on expense Lunch

## Verify Page of an Expense

* Verify that the page is displaying this message "Submit a payment request for the following expense"
* Verify that it the clicked expense that is rendered to a new page "Lunch"
* Verify history message "Previous Payment Requests for this expense"
* Verify that "Student2" is in the list of previous payments
* Verify that "Student3" is in the list of previous payments as well
* Verify if Student2 paid "Yes"
* Verify if student3 paid "No"
* Verify the total amount of payments requested is "ZAR 200.00"

## Student3 pays a payment request received from Student1

* User lands on a page
* User enters their email "student3@wethinkcode.co.za" to login
* User anvigates to PaymentRequestReceived tab
* Student clicks pay for a lunch expense
* User navigates back to expenses page
* Verify that the expense that was paid for is added on the expense page "Lunch"