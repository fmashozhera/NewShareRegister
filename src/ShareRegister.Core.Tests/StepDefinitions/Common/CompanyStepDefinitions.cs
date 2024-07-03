using FluentResults;
using NUnit.Framework;
using ShareRegister.Domain.Common;
using TechTalk.SpecFlow.Assist;

namespace ShareRegister.Core.Tests.StepDefinitions.Common
{
    [Binding]
    public class CompanyStepDefinitions
    {
        private string companyCode;
        private string companyName;
        private string isin;
        private Address address;
        private ISet<TelephoneNumber> telephoneNumbers;
        private Email email;
        private Result<Company> result;

        [Given(@"I capture the  valid values '([^']*)','([^']*)','([^']*)'")]
        public void GivenICaptureTheValidValues(string companyCode, string name, string Isin)
        {
            this.companyCode = companyCode;
            companyName = name;
            isin = Isin;
        }

        [When(@"the Address is")]
        public void WhenTheAddressIs(Table table)
        {
            Result<Address> addressResult = Address.Create(
                table.Rows[0].Value(),
                table.Rows[1].Value(),
                table.Rows[2].Value(),
                table.Rows[3].Value(),
                table.Rows[4].Value()
                );
            address = addressResult.Value;
        }

        [When(@"the telephone numbers are")]
        public void WhenTheTelephoneNumbersAre(Table table)
        {
            telephoneNumbers = new HashSet<TelephoneNumber>();
            foreach (var phoneNumber in table.Rows)
            {
                telephoneNumbers.Add(
                    TelephoneNumber.Create(phoneNumber["TelephoneNumber"], (TelephoneNumberType)Enum.Parse(typeof(TelephoneNumberType), phoneNumber["TelephoneNumberType"])).Value);
            }
        }

        [When(@"I create a company")]
        public void WhenICreateACompany()
        {
            result = Company.Create(companyCode, companyName, isin, address, email, telephoneNumbers);
        }

        [When(@"the email address")]
        public void WhenTheEmailAddress(Table table)
        {
            var emailString = table.Rows[0]["Email"];
            email = Email.Create(emailString).Value;
        }


        [Then(@"I should get a success Company result with")]
        public void ThenIShouldGetASuccessCompanyResultWith()
        {
            Assert.True(result.IsSuccess);
        }
        [When(@"I create a with invalid company details")]
        public void WhenICreateAWithInvalidCompanyDetails()
        {
            result = Company.Create(companyCode, companyName, isin, address, email, telephoneNumbers);
        }

        [Then(@"I should get a failure Company result with message '([^']*)'")]
        public void ThenIShouldGetAFailureCompanyResultWithMessage(string errorMessage)
        {
            Assert.IsTrue(result.Errors.Any(err => err.Message == errorMessage));
        }

        [Given(@"the telephone numbers are")]
        public void GivenTheTelephoneNumbersAre(Table table)
        {
            telephoneNumbers = new HashSet<TelephoneNumber>();
            foreach (var phoneNumber in table.Rows)
            {
                telephoneNumbers.Add(
                    TelephoneNumber.Create(phoneNumber["TelephoneNumber"], (TelephoneNumberType)Enum.Parse(typeof(TelephoneNumberType), phoneNumber["TelephoneNumberType"])).Value);
            }
        }

        [Given(@"the email address")]
        public void GivenTheEmailAddress(Table table)
        {
            var emailString = table.Rows[0]["Email"];
            email = Email.Create(emailString).Value;
        }

        [When(@"I create a with company no address")]
        public void WhenICreateAWithCompanyNoAddress()
        {
            result = Company.Create(companyCode, companyName, isin, null, email, telephoneNumbers);
        }


        [When(@"I create a with invalid company details with no address")]
        public void WhenICreateAWithInvalidCompanyDetailsWithNoAddress()
        {
            throw new PendingStepException();
        }


        [When(@"I create a with invalid company details with no telephone numbers")]
        public void WhenICreateAWithInvalidCompanyDetailsWithNoTelephoneNumbers()
        {
            result = Company.Create(companyCode, companyName, isin, address, email, null);
        }

        [Given(@"I have a valid company")]
        public void GivenIHaveAValidCompany()
        {
            address = Address.Create("Street", "Subrbub", "City", "Country", "263").Value;
            email = Email.Create("test@email.com").Value;
            telephoneNumbers = new HashSet<TelephoneNumber>() { TelephoneNumber.Create("1234564", TelephoneNumberType.Mobile).Value };
            result = Company.Create("TestCompany", "CompanyName", "ISIN123", address, email, telephoneNumbers);
        }


        [When(@"I create a company with no email address")]
        public void WhenICreateACompanyWithNoEmailAddress()
        {
            result = Company.Create(companyCode, companyName, isin, address, null, telephoneNumbers);
        }

        [When(@"I update a company")]
        public void WhenIUpdateACompany()
        {
            result = Company.Create(companyCode, companyName, isin, address, email, telephoneNumbers);
        }

        [When(@"I update a with invalid company details")]
        public void WhenIUpdateAWithInvalidCompanyDetails()
        {
            Company company = result.Value;
            result = company.Update(companyCode, companyName, isin, address, email, telephoneNumbers);
        }

        [When(@"I update a with company no address")]
        public void WhenIUpdateAWithCompanyNoAddress()
        {
            Company company = result.Value;
            result = company.Update(companyCode, companyName, isin, null, email, telephoneNumbers);
        }

        [When(@"I update a with invalid company details with no telephone numbers")]
        public void WhenIUpdateAWithInvalidCompanyDetailsWithNoTelephoneNumbers()
        {
            Company company = result.Value;
            result = company.Update(companyCode, companyName, isin, address, email, null);
        }

        [When(@"I update a company with no email address")]
        public void WhenIUpdateACompanyWithNoEmailAddress()
        {
            Company company = result.Value;
            result = company.Update(companyCode, companyName, isin, address, null, telephoneNumbers);
        }

        [When(@"I update a with invalid company details '([^']*)','([^']*)','([^']*)'")]
        public void WhenIUpdateAWithInvalidCompanyDetails(string companyCode, string companyName, string ISIN)
        {
            Company company = result.Value;
            result = company.Update(companyCode, companyName, ISIN, address, email, null);
        }


    }
}
