using AutomationExercise.Tests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.Tests.Pages
{
    public class AccountInformationPage : BasePage
    {
        //Enter account information
        private readonly By enterAccountInformationTitle = By.XPath("//b[text()='Enter Account Information']");

        // Title radio buttons
        private readonly By mrRadioButton = By.Id("id_gender1");

        private readonly By mrsRadioButton = By.Id("id_gender2");

        // Name
        private readonly By nameText = By.Id("name");

        // Email
        private readonly By emailText = By.Id("email");

        // Password
        private readonly By passwordText = By.Id("password");

        // Date of Birth
        private readonly By dayDropdown = By.Id("days");

        private readonly By monthDropdown = By.Id("months");

        private readonly By yearDropdown = By.Id("years");

        // Newsletter
        private readonly By newsletterCheckbox = By.Id("newsletter");

        // Special offers
        private readonly By specialOffersCheckbox = By.Id("optin");

        //First name
        private readonly By firstName = By.Id("first_name");

        //Last name
        private readonly By lastName = By.Id("last_name");

        //Address
        private readonly By address = By.Id("address1");

        //Country
        private readonly By country = By.Id("country");

        //State
        private readonly By state = By.Id("state");

        //City
        private readonly By city = By.Id("city");

        //Zipcode
        private readonly By zipcode = By.Id("zipcode");

        //Mobile number
        private readonly By mobileNumber = By.Id("mobile_number");

        //Create account
        private readonly By createAccountButton = By.CssSelector("button[data-qa='create-account']");


        public AccountInformationPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsPageOpened()
        {
            return IsDisplayed(enterAccountInformationTitle);
        }

        public void FillAccountInformation(
            string password,
            string day,
            string month,
            string year,
            string firstNameValue,
            string lastNameValue,
            string addressValue,
            string countryValue,
            string stateValue,
            string cityValue,
            string zipcodeValue,
            string mobileNumberValue)
        {
            Click(mrRadioButton);

            EnterText(passwordText, password);

            SelectByValue(dayDropdown, day);
            SelectByValue(monthDropdown, month);
            SelectByValue(yearDropdown, year);

            EnterText(firstName, firstNameValue);
            EnterText(lastName, lastNameValue);
            EnterText(address, addressValue);

            SelectByText(country, countryValue);

            EnterText(state, stateValue);
            EnterText(city, cityValue);
            EnterText(zipcode, zipcodeValue);
            EnterText(mobileNumber, mobileNumberValue);
        }

        public void CreateAccount()
        {
            Click(createAccountButton);
        }

        private void SelectByValue(By locator, string value)
        {
            var dropdown = new SelectElement(Find(locator));
            dropdown.SelectByValue(value);
        }

        private void SelectByText(By locator, string text)
        {
            var dropdown = new SelectElement(Find(locator));
            dropdown.SelectByText(text);
        }

        public string GetFirstNameValidationMessage()
        {
            return Find(firstName).GetAttribute("validationMessage") ?? string.Empty;
        }
    }
}
