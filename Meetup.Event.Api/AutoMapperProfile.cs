
using AutoMapper;
using Meetup.Event.Domain.DTOs.EventDTOs;

namespace Meetup.Event.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddEventDto, Domain.Entities.Event>();
            CreateMap<UpdateEventDto, Domain.Entities.Event>();
        }
    }
}
