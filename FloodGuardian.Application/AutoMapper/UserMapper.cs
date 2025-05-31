using AutoMapper;
using FloodGuardian.Domain.Dtos.Request;
using FloodGuardian.Domain.Dtos.Response;
using FloodGuardian.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGuardian.Application.AutoMapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserRequest, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())      
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            ;

        CreateMap<User, UserResponse>();
    }
}
