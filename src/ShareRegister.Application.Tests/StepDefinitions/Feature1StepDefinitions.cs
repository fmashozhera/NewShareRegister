using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ShareRegister.Application.Tests.StepDefinitions
{
    [Binding]
    public class Feature1StepDefinitions
    {
        int x;
        int y;
        int sum;

        [Given(@"Simple addition")]
        public void GivenSimpleAddition()
        {
            x = 1;
            y = 2;
        }

        [When(@"adding (.*) numbers")]
        public void WhenAddingNumbers(int p0)
        {
            sum = x + y;
        }

        [Then(@"i should get their sum")]
        public void ThenIShouldGetTheirSum()
        {
            Assert.AreEqual(x, sum);
        }
    }
}
