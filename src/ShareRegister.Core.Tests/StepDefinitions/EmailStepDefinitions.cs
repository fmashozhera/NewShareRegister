using FluentResults;
using NUnit.Framework;
using ShareRegister.Domain.Common;
using ShareRegister.Domain.Common.Errors;
using System;
using TechTalk.SpecFlow;

namespace ShareRegister.Core.Tests.StepDefinitions
{
    [Binding]
    public class EmailStepDefinitions
    {
        private string _email;
        private Result<Email> result;

        [Given(@"the valid ""([^""]*)""")]
        public void GivenTheValid(string email)
        {
            _email = email;
        }

        [When(@"I call Email\.Create")]
        public void WhenICallEmail_Create()
        {
            result = Email.Create(_email);
        }

        [Then(@"i should get an email result with value ""([^""]*)"" and success ""([^""]*)""")]
        public void ThenIShouldGetAnEmailResultWithValueAndSuccess(string value, string status)
        {            
            Assert.That(value, Is.EqualTo(result.Value.Value));
            Assert.IsTrue(Boolean.Parse(status)==result.IsSuccess);
        }

        [Then(@"i should get an email result with message ""([^""]*)"" and success ""([^""]*)""")]
        public void ThenIShouldGetAnEmailResultWithMessageAndSuccess(string emailErrorMessage, string @false)
        {
            Assert.IsTrue(result.HasError<InvalidEmailError>());
            Assert.IsTrue(result.Errors.FirstOrDefault(t => t.Message == emailErrorMessage) != null);
            Assert.AreEqual(bool.Parse(@false), result.IsSuccess);
        }


        [Given(@"an empty email address")]
        public void GivenAnEmptyEmailAddress()
        {
            _email = "";
        }

        [Then(@"i should get an Email is required error message ""([^""]*)""")]
        public void ThenIShouldGetAnEmailIsRequiredErrorMessage(string emailRequiredMessage)
        {
            Assert.IsTrue(result.HasError<RequiredError>());
            Assert.IsTrue(result.Errors.FirstOrDefault(t => t.Message == emailRequiredMessage) != null);
        }

    }
}
