using Apsiyon.Application.Dto;
using Apsiyon.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Application.Profiles
{
    public class FloorProfile : Profile
    {
        public FloorProfile()
        {
            CreateMap<FloorViewDto, Floor>().ReverseMap();
        }
    }
}
