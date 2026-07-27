# automation-exercise-csharp-selenium
UI and API Test Automation Framework using C#, Selenium WebDriver, NUnit and RestSharp.

**##Technologies Used**
- **C#**
- **.NET**
- **Selenium WebDriver**
- **NUnit**
- **RestSharp**
- **System.Text.Json**
- **ChromeDriver**
- **Visual Studio**
- **Git and GitHub**

**##Project Structure**
AutomationExercise.Tests
├── API
│   ├── Clients
│   │   └── UserApiClients.cs
│   └── Models
│       ├── ApiResponseModel.cs
│       ├── UserDetailsResponseModel.cs
│       └── UserRequestModel.cs
├── Base
│   ├── BasePage.cs
│   └── BaseTest.cs
├── Drivers
│   └── DriverFactory.cs
├── Helpers
│   └── RandomDataGenerator.cs
├── Pages
│   ├── AccountCreatedPage.cs
│   ├── AccountDeletedPage.cs
│   ├── AccountInformationPage.cs
│   ├── CookieBanner.cs
│   ├── HomePage.cs
│   └── LoginSignupPage.cs
├── TestData
│   └── LoginSignupTestData.cs
└── Tests
    ├── API
    │   └── UserApiTests.cs
    └── UI
        ├── HomePageTests.cs
        └── LoginSignupTests.cs

**##Automated Scenarios**
### UI Tests

- Verify that the home page loads successfully
- Verify login with invalid credentials is unsuccessful
- Register a new user through the complete UI flow successfully
- Verify required-field validation during registration shows validation error

### API Tests

- Create a user and retrieve the correct user details
- Create and delete a user
- Create, update and verify user details

**##Prerequisites**

Before running the project, make sure the following are installed:
- .NET SDK
- Google Chrome
- Visual Studio or another compatible IDE
- Git

**##Design**

Page Object Model is used.
BasePage contains reusable Selenium operations such as clicking, entering text, navigation, and element lookup.
BaseTest manages WebDriver setup and teardown before and after every UI test.
DriverFactory is responsible for creating the browser driver.
API request logic is separated from the tests and placed in UserApiClient.
Request and response models are used for clearer API data handling and JSON deserialization.
Random test data is generated to prevent conflicts with existing users.
UI and API tests are stored in separate folders.

**##Possible improvements and further development of the project**

Add automatic cleanups for users that are created with UI and API tests.
Add Github Actions for CI.
Add explicit waits for specific elements.
Add additional UI and API positive and negative scenarios.
Develop further the project by using the Products page functionalities.
Add support for running the tests in multiple browsers.

