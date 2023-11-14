using Application.Contracts.User.DTOs;
using AutoMapper;
using Infrastructure.Identity.Models;

namespace Infrastructure.Identity.Mappings;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUser, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
    }
}