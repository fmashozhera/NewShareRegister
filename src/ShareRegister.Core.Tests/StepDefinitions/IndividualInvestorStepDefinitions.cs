using FluentResults;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ShareRegister.Domain.Common;
using ShareRegister.Tests.CommonHelpers;
using ShareRegister.Domain.Extenstions;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;

namespace ShareRegister.Core.Tests.StepDefinitions
{
    [Binding]
    public class IndividualInvestorStepDefinitions
    {
        Result<IndividualInvestor> investorResult;
        Address address;
        Email email;
        TelephoneNumber telephoneNumber;
        string title;
        string firstName;
        string surname;
        string identificationNumber;
        string identificationType;

        [BeforeScenario]
        private void Setup()
        {
            address = null;
            email = null;
            telephoneNumber = null;
            investorResult = null;
        }

        [Given(@"I capture the following individual investor information  '([^']*)','([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void GivenICaptureTheFollowingIndividualInvestorInformation(string title, string firstName, string surname, string identificationNumber, string identificationType)
        {
            this.title = title;
            this.firstName = firstName;
            this.surname = surname;
            this.identificationNumber = identificationNumber; 
            this.identificationType = identificationType;
        }

        [Given(@"the investor address is")]
        public void GivenTheInvestorAddressIs(Table addressData)
        {
            address = addressData.CreateInstance<Address>();
        }

        [Given(@"the investor email address is")]
        public void GivenTheInvestorEmailAddressIs(Table emailAddressData)
        {
            email = emailAddressData.CreateInstance<Email>();
        }

        [Given(@"the investor telephone number is")]
        public void GivenTheInvestorTelephoneNumberIs(Table telephoneNumberData)
        {
            telephoneNumber = telephoneNumberData.CreateInstance<TelephoneNumber>();
        }


        [When(@"i save the investor information")]
        public void WhenISaveTheInvestorInformation()
        {
            investorResult = IndividualInvestor.Create(title, firstName, surname, identificationNumber, identificationType.GetEnumValue<IdentificationType>(), address, email, telephoneNumber);
        }

        [Then(@"I should get a sucess individual investor result")]
        public void ThenIShouldGetASucessIndividualInvestorResult()
        {
            Assert.IsTrue(investorResult.IsSuccess);
        }
    }
}
