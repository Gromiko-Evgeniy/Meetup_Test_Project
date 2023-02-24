
using AutoMapper;
using Meetup.Login.Domain.DTOs.UserDTOs;
using Meetup.Login.Domain.Entities;

namespace Meetup.Event.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddUserDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
