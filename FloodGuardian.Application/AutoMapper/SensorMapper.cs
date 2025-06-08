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

public class SensorMapper : Profile
{
    public SensorMapper()
    {
        CreateMap<SensorDataRequest, SensorData>()
            .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<SensorData, SensorDataResponse>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                src.NivelAgua >= 2.5 ? "RISCO" : "NORMAL"));
    }
}