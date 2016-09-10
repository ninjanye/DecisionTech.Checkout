# Decision Tech Price Calculation
### Project Structure
This project consists of 3 projects.

* `DecisionTech.Checkout` - This is the main project for the application and
contains the business logic.
* `DecisionTech.Checkout.Tests.Acceptance` - This holds the BDD style tests and
utilises [SpecFlow] to translate the tests to runnable code. These feature tests
were used to drive out the functionality.
* `DecisionTech.Checkout.Tests.Unit` - This holds the unit tests for the
project. The test have split up by feature.


[SpecFlow]: http://www.specflow.org/
