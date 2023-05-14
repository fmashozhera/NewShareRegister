using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareRegister.API.DTOs;
using ShareRegister.Application.Companies.Commands;

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
    public async Task<IActionResult> Create(CreateCompanyDTO companyDto)
    {
        CreateCompanyCommand command = new CreateCompanyCommand()
        {
            Name = companyDto.Name,
            City = companyDto.City,
            Street = companyDto.Street,
            Surburb = companyDto.Surburb,   
            ISIN = companyDto.ISIN,
            CompanyCode = companyDto.CompanyCode,
            Country = companyDto.Country,   
            ZipCode = companyDto.ZipCode,   
        };

        var createCompanyResult = await _mediator.Send(command);
        if (createCompanyResult.IsSuccess)
        {
            return Ok();
        }
        else
        {
            return BadRequest(createCompanyResult.Errors.ToString());
        }
    }
}
