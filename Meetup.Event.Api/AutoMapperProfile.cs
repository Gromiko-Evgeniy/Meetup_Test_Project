
using AutoMapper;
using Meetup.Event.Api.DTOs.EventDTOs;
using Meetup.Event.Api.Entities;

namespace Meetup.Event.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetEventDTO, Entities.Event>();
            CreateMap<AddEventDto, Entities.Event>();
            CreateMap<UpdateEventDto, Entities.Event>();

            CreateMap<Entities.Event, GetEventDTO>();
        }
    }
}
