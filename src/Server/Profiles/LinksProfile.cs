using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MindPalace.Server.Entities;
using MindPalace.Shared.Dtos;

namespace MindPalace.Server.Profiles
{
    public class LinksProfile : Profile
    {
        public LinksProfile()
        {
            CreateMap<LinkToCreateDto, Link>();
        }
    }
}