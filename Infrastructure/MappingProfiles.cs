﻿using AutoMapper;
using Common.Responses.Identity;
using Infrastructure.Models;

namespace Infrastructure;

internal class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ApplicationUser, UserResponse>();
        CreateMap<ApplicationRole, RoleResponse>();
        CreateMap<ApplicationRoleClaim, RoleClaimViewModel>().ReverseMap();
    }
}