using FluentResults;
using NUnit.Framework;
using ShareRegister.Domain.Common;
using System;
using TechTalk.SpecFlow;

namespace ShareRegister.Core.Tests.StepDefinitions.Common
{
    [Binding]
    public class TelephoneNumberStepDefinitions
    {
        private TelephoneNumber telephoneNumber;
        private string telephoneNumberValue;
        private TelephoneNumberType telephoneNumberType;
        private Result<TelephoneNumber> result;

        [Given(@"the valid '([^']*)' with type '([^']*)'")]
        public void GivenTheValidWithType(string telephoneNumberValue, string telephoneNumberType)
        {
            this.telephoneNumberValue = telephoneNumberValue;
            this.telephoneNumberType = (TelephoneNumberType)Enum.Parse(typeof(TelephoneNumberType), telephoneNumberType);
        }

        [When(@"I call TelephoneNumber\.Create")]
        public void WhenICallTelephoneNumber_Create()
        {
            result = TelephoneNumber.Create(telephoneNumberValue, telephoneNumberType);
        }

        [Given(@"the invalid ""([^""]*)"" with type '([^']*)'")]
        public void GivenTheInvalidWithType(string telephoneNumberValue, string telephoneNumberType)
        {
            this.telephoneNumberValue = telephoneNumberValue;
            this.telephoneNumberType = (TelephoneNumberType)Enum.Parse(typeof(TelephoneNumberType), telephoneNumberType);
        }

        [Then(@"i should get a success telephone number result with '([^']*)'")]
        public void ThenIShouldGetASuccessTelephoneNumberResultWith(string @true)
        {
            Assert.IsTrue(result.IsSuccess);
        }

        [Then(@"i should get a failure telephone number result with message ""([^""]*)""")]
        public void ThenIShouldGetAFailureTelephoneNumberResultWithMessage(string message)
        {
            Assert.AreEqual(message, result.Errors[0].Message);
        }

    }
}
