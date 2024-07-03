using FluentResults;
using NUnit.Framework;
using ShareRegister.Domain.Common;
using ShareRegister.Domain.Common.Errors;
using System;
using TechTalk.SpecFlow;

namespace ShareRegister.Core.Tests.StepDefinitions.Common
{
    [Binding]
    public class AddressStepDefinitions
    {
        private Address _address = null!;
        private Result<Address> _result = null!;
        private string _street = null!;
        private string _city = null!;
        private string _surburb = null!;
        private string _country = null!;
        private string _postalCode = null!;

        [Given(@"I capture the  valid values ""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)""")]
        public void GivenICaptureTheValidValues(string street, string surburb, string city, string country, string postalCode)
        {
            _street = street;
            _surburb = surburb;
            _city = city;
            _country = country;
            _postalCode = postalCode;
        }

        [When(@"I create an address")]
        public void WhenICreateAnAddress()
        {
            _result = Address.Create(_street, _surburb, _city, _country, _postalCode);
        }

        [Then(@"I should get a success Address result with values ""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)""")]
        public void ThenIShouldGetASuccessAddressResultWithValues(string street, string surburb, string city, string country, string postalCode)
        {
            Assert.IsTrue(_result.IsSuccess);
            var createdAddress = _result.Value;
            Assert.AreEqual(street, createdAddress.Street);
            Assert.AreEqual(surburb, createdAddress.Surburb);
            Assert.AreEqual(city, createdAddress.City);
            Assert.AreEqual(surburb, createdAddress.Surburb);
            Assert.AreEqual(postalCode, createdAddress.PostalCode);
        }

        [Given(@"I capture the invalid values ""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)""")]
        public void GivenICaptureTheInvalidValues(string street, string surburb, string city, string country, string postalCode)
        {
            _street = street;
            _surburb = surburb;
            _city = city;
            _country = country;
            _postalCode = postalCode;
        }

        [Then(@"I should get a failure Address result with message ""([^""]*)""")]
        public void ThenIShouldGetAFailureAddressResultWithMessage(string errorMessage)
        {
            Assert.IsTrue(_result.IsFailed);
            Assert.IsTrue(_result.HasError<InvalidAddressError>());
            Assert.IsTrue(_result.Errors.Any(t => t.Message == errorMessage));
        }

        [When(@"I update an address")]
        public void WhenIUpdateAnAddress()
        {
            _result = _address.Update(_street, _surburb, _city, _country, _postalCode);
        }

        [When(@"I Create a valid address")]
        public void WhenICreateAValidAddress()
        {
            _result = Address.Create("Street", "Surbub", "City", "Country", "263");
            _address = _result.Value;
        }

        [Given(@"I have a  valid address with values ""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)""")]
        public void GivenIHaveAValidValuesWithValues(string street, string surburb, string city, string country, string postalCode)
        {
            _result = Address.Create(street, surburb, city, country, postalCode);
            _address = _result.Value;
        }

        [Given(@"I update the address with the following values  ""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)""")]
        public void GivenIUpdateTheAddressWithTheFollowingValues(string street, string surburb, string city, string country, string postalCode)
        {
            _result = _address.Update(street, surburb, city, country, postalCode);
        }
    }
}
