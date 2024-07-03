using FakeItEasy;
using FluentResults;
using NUnit.Framework;
using ShareRegister.Domain.Common;

namespace ShareRegister.Core.Tests.StepDefinitions.Common
{
    [Binding]
    public class BankStepDefinitions
    {
        Bank bank;
        ISet<TelephoneNumber> telephoneNumbers;
        Address address;
        string bankName;
        string bankCode;
        string branchName;
        string branchCode;
        Guid creatorId;
        DateTime createdDate;
        Result<Bank> bankResult;
        Result<BankBranch> bankBranchResult;

        [BeforeScenario]
        public void Setup()
        {
            telephoneNumbers = new HashSet<TelephoneNumber>();
        }

        [Given(@"I enter the following valid bank informtion '([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void GivenIEnterTheFollowingValidBankInformtion(string name, string bankCode, string street, string surburb, string city, string country, string postalCode, Guid creatorId)
        {
            Result<Address> addressResult = Address.Create(street, surburb, city, country, postalCode);
            address = addressResult.Value;
            bankName = name;
            this.bankCode = bankCode;
            this.creatorId = creatorId;
        }

        [When(@"I create the bank")]
        public void WhenICreateTheBank()
        {
            bankResult = Bank.Create(bankCode, bankName, address, telephoneNumbers);
        }

        [Then(@"I should get a success bank result")]
        public void ThenIShouldGetASuccessBankResult()
        {
            Assert.True(bankResult.IsSuccess);
            bank = bankResult.Value;
            Assert.AreEqual(bankCode, bank.BankCode);
        }

        [Then(@"I should get a failure result with message '([^']*)'")]
        public void ThenIShouldGetAFailureResultWithMessage(string errorMessage)
        {
            Assert.True(bankResult.Errors.Select(t => t.Message).Contains(errorMessage));
        }

        [Given(@"I enter the following valid bank informtion '([^']*)','([^']*)','([^']*)'")]
        public void GivenIEnterTheFollowingValidBankInformtion(string bankCode, string name, Guid creatorId)
        {
            address = null;
            bankName = name;
            this.bankCode = bankCode;
            this.creatorId = creatorId;
        }

        [Given(@"I enter the following valid bank informtion '([^']*)','([^']*)'")]
        public void GivenIEnterTheFollowingValidBankInformtion(string bankName, string bankCode)
        {
            this.bankName = bankName;
            this.bankCode = bankCode;
        }

        [Given(@"the telephone numbers")]
        public void GivenTheTelephoneNumbers(Table telephoneNumbersTable)
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

        [Given(@"the Address")]
        public void GivenTheAddress(Table addressData)
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

        [Given(@"I enter the following branch details '([^']*)','([^']*)'")]
        public void GivenIEnterTheFollowingBranchDetails(string branchName, string branchCode)
        {
            this.branchName = branchName;
            this.branchCode = branchCode;
        }

        [When(@"I save the branch")]
        public void WhenISaveTheBranch()
        {
            bankBranchResult = bank.AddBranch(branchName, branchCode);
        }

        [Then(@"I should get a success result")]
        public void ThenIShouldGetASuccessResult()
        {
            Assert.IsTrue(bankBranchResult.IsSuccess);
        }

        [Given(@"I have a bank with the following details '([^']*)','([^']*)'")]
        public void GivenIHaveABankWithTheFollowingDetails(string bankName, string bankCode)
        {
            this.bankName = bankName;
            this.bankCode = bankCode;
        }

        [When(@"I get the bank")]
        public void WhenIGetTheBank()
        {
            bankResult = Bank.Create(bankCode, bankName, address, telephoneNumbers);
            if (bankResult.IsSuccess) { bank = bankResult.Value; }
        }

        [When(@"I enter the following branch details '([^']*)','([^']*)'")]
        public void WhenIEnterTheFollowingBranchDetails(string branchName, string branchCode)
        {
            this.branchName = branchName;
            this.branchCode = branchCode;
        }

        [Then(@"I should get a failure branch result with message '([^']*)'")]
        public void ThenIShouldGetAFailureBranchResultWithMessage(string errorMessage)
        {
            Assert.IsTrue(bankBranchResult.Errors.Select(t => t.Message).Contains(errorMessage));
        }

    }
}
