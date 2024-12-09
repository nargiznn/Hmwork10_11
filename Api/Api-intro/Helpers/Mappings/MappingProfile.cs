using Api_intro.DTOs.City;
using Api_intro.DTOs.Countries;
using Api_intro.DTOs.Group;
using Api_intro.Models;
using AutoMapper;

namespace Api_intro.Helpers.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryEditDto, Country>()
            .ForAllMembers(opts =>
            {
                opts.AllowNull();
                opts.Condition((src, dest, srcMember) => srcMember != null );
            });

            CreateMap<CityCreateDto, City>();
            CreateMap<CityEditDto, City>()
                .ForAllMembers(opts =>
                {
                    opts.AllowNull();
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            CreateMap<City, CityDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));

            CreateMap<GroupCreateDto, Group>();
        }
    }
}
