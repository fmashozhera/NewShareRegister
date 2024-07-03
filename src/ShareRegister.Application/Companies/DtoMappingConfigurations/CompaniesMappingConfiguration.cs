using AutoMapper;
using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Companies.DtoMappingConfigurations;
public class CompaniesMappingConfiguration : Profile
{
    public CompaniesMappingConfiguration()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(t => t.Street, src => src.MapFrom(x => x.Address.Street))
            .ForMember(t => t.Surburb, src => src.MapFrom(x => x.Address.Surburb))
            .ForMember(t => t.City, src => src.MapFrom(x => x.Address.City))
            .ForMember(t => t.Country, src => src.MapFrom(x => x.Address.Country))
            .ForMember(t => t.Email, src => src.MapFrom(x => x.Email.Value))
            .ForMember(t => t.TelephoneNumbers, src => src.MapFrom<CompanyDtoTelephoneNumbersResolver>());

        //CreateMap<TelephoneNumber, DictionaryEntry>()
        //    .ForMember(t => t.Key, src => src.MapFrom(x => x.Value))
        //    .ForMember(t => t.Value, src => src.MapFrom(x => x.TelephoneNumberType));

        CreateMap<CompanyDto, Company>();
    }

    private class CompanyDtoTelephoneNumbersResolver : IValueResolver<Company,CompanyDto,IDictionary<string,TelephoneNumberType>>
    {
        public IDictionary<string, TelephoneNumberType> Resolve(Company source, CompanyDto destination, IDictionary<string, TelephoneNumberType> destMember, ResolutionContext context)
        {
            Dictionary<string, TelephoneNumberType> telephoneNumbers = new();
            foreach (var telephoneNumber in source.TelephoneNumbers)
            {
                telephoneNumbers.Add(telephoneNumber.Value, telephoneNumber.TelephoneNumberType);
            }
            return telephoneNumbers;
        }
    }

    private class CompanyTelephoneNumbersResolver : IValueResolver<CompanyDto, Company, ISet<TelephoneNumber>>
    {
        public ISet<TelephoneNumber> Resolve(CompanyDto source, Company destination, ISet<TelephoneNumber> destMember, ResolutionContext context)
        {
            HashSet<TelephoneNumber> telephoneNumbers = new ();
            foreach (var telephoneNumber in source.TelephoneNumbers)
            {
                var telephoneNumberResult = TelephoneNumber.Create(telephoneNumber.Key, telephoneNumber.Value);
                if (telephoneNumberResult.IsSuccess) { telephoneNumbers.Add(telephoneNumberResult.Value); }
            }
            return telephoneNumbers;
        }
    }
}
