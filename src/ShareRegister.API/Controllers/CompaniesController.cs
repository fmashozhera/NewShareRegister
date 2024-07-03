using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareRegister.API.DTOs;
using ShareRegister.Application.Companies.Commands;
using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Companies.Queries;
using ShareRegister.Application.Companies.Specifications;
using System.Linq;

namespace ShareRegister.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompaniesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCompanyDto companyDto)
    {
        CreateCompanyCommand command = new CreateCompanyCommand() { CompanyData = companyDto };        
        var createCompanyResult = await _mediator.Send(command);
        if (createCompanyResult.IsSuccess)
        {
            return Ok();
        }
        else
        {
            return BadRequest(createCompanyResult.Errors.Select(error => error.Message));
        }
    }

    [HttpGet]  
    public async Task<IActionResult> GetAll([FromQuery]int skip, [FromQuery]int take)
    {
        GetAllCompaniesQuery query = new GetAllCompaniesQuery() { Skip = skip,Take = take};
        var companies = (await _mediator.Send(query)).Value;                
        return Ok(companies);
    }

    [HttpGet]
    [Route("getByCompanyCode/{companyCode}")]
    public async Task<IActionResult> GetCompanyByCompanyCode(string companyCode)
    {
        GetCompanyByCompanyCodeQuery query = new GetCompanyByCompanyCodeQuery() { CompanyCode = companyCode };
        var company = (await _mediator.Send(query)).Value;       
        return Ok(company);
    }

    [HttpGet]
    [Route("getByISIN/{ISIN}")]
    public async Task<IActionResult> GetCompanyByISIN(string ISIN)
    {
        GetCompanyByISINQuery query = new GetCompanyByISINQuery() { ISIN = ISIN };
        var company = (await _mediator.Send(query)).Value;        
        return Ok(company);
    }

    [HttpPut] 
    public async Task<IActionResult> Update(CreateCompanyDto companyDto)
    {
        UpdateCompanyCommand command = new UpdateCompanyCommand() { Company = companyDto };
        var createCompanyResult = await _mediator.Send(command);
        if (createCompanyResult.IsSuccess)
        {
            return Ok();
        }
        else
        {
            return BadRequest(createCompanyResult.Errors.Select(error => error.Message));
        }
    }
}
