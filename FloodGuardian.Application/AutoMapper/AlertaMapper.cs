using AutoMapper;
using FloodGuardian.Domain.Dtos.Response;
using FloodGuardian.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGuardian.Application.AutoMapper;

public class AlertaMapper : Profile
{
    public AlertaMapper()
    {
        CreateMap<Alerta, AlertaResponse>();
    }
}