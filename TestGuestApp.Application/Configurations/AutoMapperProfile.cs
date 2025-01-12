using AutoMapper;
using TestGuestApp.Application.Commands.AddGuest;
using TestGuestApp.Application.Commands.AddPhone;
using TestGuestApp.Application.DTOs;
using TestGuestApp.Core.Entities;
using TestGuestApp.Core.Enums;

namespace TestGuestApp.Application.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Guest, GuestDTO>();

            CreateMap<AddGuestCommand, Guest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => Enum.Parse<Title>(src.Title)));

            CreateMap<AddGuestDTO, AddGuestCommand>();

            CreateMap<AddPhoneDTO, AddPhoneCommand>();

            CreateMap<IEnumerable<Guest>, IEnumerable<GuestDTO>>()
            .ConvertUsing((src, dest, context) => src.Select(x => context.Mapper.Map<GuestDTO>(x)).ToList());
        }
    }
}
