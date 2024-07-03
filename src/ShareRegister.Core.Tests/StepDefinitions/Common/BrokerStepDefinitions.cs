using FluentResults;
using NUnit.Framework;
using ShareRegister.Domain.Common;
using System;
using TechTalk.SpecFlow;

namespace ShareRegister.Core.Tests.StepDefinitions.Common
{
    [Binding]
    public class BrokerStepDefinitions
    {
        Result<Broker> brokerResult;
        string brokerCode;
        string brokerName;
        ISet<TelephoneNumber> telephoneNumbers;
        Address address;
        Broker broker;

        [BeforeScenario]
        public void Setup()
        {
            telephoneNumbers = new HashSet<TelephoneNumber>();
            broker = null;
        }

        [Given(@"I capture the following broker information '([^']*)','([^']*)'")]
        public void GivenICaptureTheFollowingBrokerInformation(string brokcerCode, string name)
        {
            brokerCode = brokcerCode;
            brokerName = name;
        }

        [When(@"I save the broker information")]
        public void WhenISaveTheBrokerInformation()
        {
            brokerResult = Broker.Create(brokerCode, brokerName, address, telephoneNumbers);
        }

        [Then(@"Then I should get a success broker result")]
        public void ThenThenIShouldGetASuccessBrokerResult()
        {
            Assert.IsTrue(brokerResult.IsSuccess);
        }

        [Given(@"the broker telephone numbers")]
        public void GivenTheBrokerTelephoneNumbers(Table telephoneNumbersTable)
        {
            foreach (var telephoneNumberData in telephoneNumbersTable.Rows)
            {
                Result<TelephoneNumber> telephoneNumberResult = TelephoneNumber.Create(telephoneNumberData["TelephoneNumber"].ToString(),
                                                                                       (TelephoneNumberType)Enum.Parse(typeof(TelephoneNumberType),
                                                                                       telephoneNumberData["TelephoneNumberType"].ToString()));
                if (telephoneNumberResult.IsSuccess)
                {
                    telephoneNumbers.Add(telephoneNumberResult.Value);
                }
            }
        }

        [Given(@"the broker Address")]
        public void GivenTheBrokerAddress(Table addressData)
        {
            Result<Address> addressResult;
            addressResult = Address.Create(
                addressData.Rows.FirstOrDefault(t => t["Field"].ToString() == "Street")["Value"].ToString(),
                addressData.Rows.FirstOrDefault(t => t["Field"].ToString() == "Surburb")["Value"].ToString(),
                addressData.Rows.FirstOrDefault(t => t["Field"].ToString() == "City")["Value"].ToString(),
                addressData.Rows.FirstOrDefault(t => t["Field"].ToString() == "Country")["Value"].ToString(),
                addressData.Rows.FirstOrDefault(t => t["Field"].ToString() == "PostalCode")["Value"].ToString());

            if (addressResult.IsSuccess)
            {
                address = addressResult.Value;
            }
        }

        [Then(@"Then I should get a failure broker result with message '([^']*)'")]
        public void ThenThenIShouldGetAFailureBrokerResultWithMessage(string errorMessage)
        {
            Assert.IsTrue(brokerResult.Errors.Select(t => t.Message).Contains(errorMessage));
        }

        [Given(@"I have a broker with the following information  '([^']*)','([^']*)'")]
        public void GivenIHaveABrokerWithTheFollowingInformation(string brokerCode, string brokerName)
        {
            this.brokerCode = brokerCode;
            this.brokerName = brokerName;
        }

        [When(@"I retrieve the broker information")]
        public void WhenIRetrieveTheBrokerInformation()
        {
            brokerResult = Broker.Create(brokerCode, brokerName, address, telephoneNumbers);
            if (brokerResult.IsSuccess)
            {
                broker = brokerResult.Value;
            }
        }

        [When(@"I update the information with the following valid information '([^']*)','([^']*)' but do not provide an address")]
        public void WhenIUpdateTheInformationWithTheFollowingValidInformationButDoNotProvideAnAddress(string brokerCode, string brokerName)
        {
            address = null;
            brokerResult = broker.Update(brokerCode, brokerName, address, telephoneNumbers);
        }


        [When(@"I update the information with the following valid information '([^']*)','([^']*)'")]
        public void WhenIUpdateTheInformationWithTheFollowingValidInformation(string brokerCode, string brokerName)
        {
            brokerResult = broker.Update(brokerCode, brokerName, address, telephoneNumbers);
        }


        [Then(@"I should get a success broker result with the broker information updated to '([^']*)','([^']*)'")]
        public void ThenIShouldGetASuccessBrokerResultWithTheBrokerInformationUpdatedTo(string brokerCode, string brokerName)
        {
            broker = brokerResult.Value;
            Assert.AreEqual(brokerCode, broker.BrokerCode);
            Assert.AreEqual(brokerName, broker.Name);
        }

        [When(@"I update the information with the following valid information '([^']*)','([^']*)' but do not provide telepone numbers")]
        public void WhenIUpdateTheInformationWithTheFollowingValidInformationButDoNotProvideTeleponeNumbers(string brokerCode, string brokerName)
        {
            telephoneNumbers = null;
            brokerResult = broker.Update(brokerCode, brokerName, address, telephoneNumbers);
        }
    }
}
