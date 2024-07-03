using AutoMapper;
using FakeItEasy;
using FluentResults;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ShareRegister.Application.Companies.CommandHandlers;
using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Companies.Queries;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Domain.Common;
using System.IO;
using System.Xml.Linq;

namespace ShareRegister.Application.Tests.StepDefinitions
{
    [Binding]
    public class CompanyStepDefinitions
    {
        CreateCompanyDto CreateCompanyDto { get; set; } = new CreateCompanyDto();
        CreateCompanyCommandHandler CreateCommandHandler { get; set; }
        public Result<CompanyDto> Result { get; set; }

        IMapper mapper ;
        ICompanyRepository companies;
        IUnitOfWork unitIfWork;

        [BeforeScenario]
        public void Setup()
        {
            mapper = A.Fake<IMapper>();
            companies = A.Fake<ICompanyRepository>();
            unitIfWork = A.Fake<IUnitOfWork>();
        }

        [Given(@"I provide the following information '([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void GivenIProvideTheFollowingInformation(string companyCode, string name, string isin, string street, string surburb, string city, string country, string postalCode, string email)
        {
            A.CallTo(() => companies.GetCompanyByCompanyCode(companyCode)).Returns(null);
            A.CallTo(() => companies.GetCompanyByISIN(isin)).Returns(null);
            A.CallTo(() => companies.GetCompanyByName(name)).Returns(null);
            CreateCompanyDto.CompanyCode = companyCode;
            CreateCompanyDto.Name = name;
            CreateCompanyDto.Surburb = surburb;
            CreateCompanyDto.City = city;
            CreateCompanyDto.Country = country;
            CreateCompanyDto.PostalCode = postalCode;
            CreateCompanyDto.Email = email;
            CreateCompanyDto.ISIN = isin;
            CreateCompanyDto.Street = street;
        }

        [When(@"I create a company")]
        public void WhenICreateACompany()
        {
            CreateCompanyCommandHandler handler = new CreateCompanyCommandHandler(companies, unitIfWork, mapper);
            var command = new Companies.Commands.CreateCompanyCommand() { CompanyData = CreateCompanyDto };
            Result = handler.Handle(command, new CancellationToken()).Result;
        }

        [Then(@"I should get a success Company result with")]
        public void ThenIShouldGetASuccessCompanyResultWith()
        {
            A.CallTo(() => unitIfWork.SaveChangesAsync()).MustHaveHappenedOnceExactly();
            A.CallTo(() => mapper.Map<CompanyDto>(A<Company>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => companies.AddAsync(A<Company>._)).MustHaveHappenedOnceExactly();
            Assert.AreEqual(true, Result.IsSuccess);
        }

        [Given(@"the telephone numbers are")]
        public void GivenTheTelephoneNumbersAre(Table table)
        {
            CreateCompanyDto.TelephoneNumbers = new Dictionary<string, TelephoneNumberType>();
            foreach (var row in table.Rows)
            {
                CreateCompanyDto.TelephoneNumbers.Add(row["TelephoneNumber"].ToString(), (TelephoneNumberType)Enum.Parse(typeof(TelephoneNumberType), row["TelephoneNumberType"].ToString()));
            }
        }

        [Given(@"I provide the following information with existing company code '([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void GivenIProvideTheFollowingInformationWithExistingCompanyCode(string existingCompanyCode, string companyCode, string name, string isin, string street, string surburb, string city, string country, string postalCode, string email)
        {
            A.CallTo(() => companies.GetCompanyByCompanyCode(existingCompanyCode)).Returns(new Company());            
            A.CallTo(() => companies.GetCompanyByName(name)).Returns(null);
            A.CallTo(() => companies.GetCompanyByISIN(isin)).Returns(null);

            CreateCompanyDto.CompanyCode = companyCode;
            CreateCompanyDto.Name = name;
            CreateCompanyDto.Surburb = surburb;
            CreateCompanyDto.City = city;
            CreateCompanyDto.Country = country;
            CreateCompanyDto.PostalCode = postalCode;
            CreateCompanyDto.Email = email;
            CreateCompanyDto.ISIN = isin;
            CreateCompanyDto.Street = street;
        }


        [Then(@"I should get a failure Company result with error message '([^']*)'")]
        public void ThenIShouldGetAFailureCompanyResultWithErrorMessage(string expectedErrorMessage)
        {
            Assert.AreEqual(true, Result.IsFailed);
            Assert.IsTrue(Result.Errors.Select(err => err.Message).Contains(expectedErrorMessage));
        }

        [Given(@"I provide the following information with existing company name '([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void GivenIProvideTheFollowingInformationWithExistingCompanyName(string companyCode, string name, string isin, string street, string surburb, string city, string country, string postalCode, string email)
        {
            A.CallTo(() => companies.GetCompanyByName(A<String>._)).Returns(new Company());
            A.CallTo(() => companies.GetCompanyByCompanyCode(companyCode)).Returns(null);
            A.CallTo(() => companies.GetCompanyByISIN(isin)).Returns(null);

            CreateCompanyDto.CompanyCode = companyCode;
            CreateCompanyDto.Name = name;
            CreateCompanyDto.Surburb = surburb;
            CreateCompanyDto.City = city;
            CreateCompanyDto.Country = country;
            CreateCompanyDto.PostalCode = postalCode;
            CreateCompanyDto.Email = email;
            CreateCompanyDto.ISIN = isin;
            CreateCompanyDto.Street = street;
        }

        [Given(@"I provide the following information with existing company ISIN '([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)','([^']*)'")]
        public void GivenIProvideTheFollowingInformationWithExistingCompanyISIN(string companyCode, string name, string isin, string street, string surburb, string city, string country, string postalCode, string email)
        {
            A.CallTo(() => companies.GetCompanyByName(A<String>._)).Returns(null);
            A.CallTo(() => companies.GetCompanyByCompanyCode(companyCode)).Returns(null);
            A.CallTo(() => companies.GetCompanyByISIN(isin)).Returns(new Company());
            CreateCompanyDto.CompanyCode = companyCode;
            CreateCompanyDto.Name = name;
            CreateCompanyDto.Surburb = surburb;
            CreateCompanyDto.City = city;
            CreateCompanyDto.Country = country;
            CreateCompanyDto.PostalCode = postalCode;
            CreateCompanyDto.Email = email;
            CreateCompanyDto.ISIN = isin;
            CreateCompanyDto.Street = street;
        }

    }
}
