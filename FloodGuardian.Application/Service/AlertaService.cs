using AutoMapper;
using FloodGuardian.Domain.Dtos.Request;
using FloodGuardian.Domain.Dtos.Response;
using FloodGuardian.Domain.Models;
using FloodGuardian.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGuardian.Application.Service;

public class AlertaService
{
    private readonly FloodGuardianContext _context;
    private readonly IMapper _mapper;

    public AlertaService(FloodGuardianContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void DispararAlerta(Guid sensorDataId, string mensagem, string tipo = "AUTOMATICO")
    {
        var sensor = _context.Sensor.FirstOrDefault(s => s.Id == sensorDataId);
        if (sensor == null) return;

        var alerta = new Alerta
        {
            SensorDataId = sensor.Id,
            SensorId = sensor.SensorId,
            Mensagem = mensagem,
            Tipo = tipo,
            DataHora = DateTime.UtcNow
        };

        _context.Alertas.Add(alerta);
        _context.SaveChanges();
    }

    public List<AlertaResponse> ListarAlertasRecentes(int qtd = 10)
    {
        var alertas = _context.Alertas
            .OrderByDescending(a => a.DataHora)
            .Take(qtd)
            .ToList();

        return _mapper.Map<List<AlertaResponse>>(alertas);
    }

    public List<AlertaResponse> BuscarPorSensor(string sensorId)
    {
        var alertas = _context.Alertas
            .Where(a => a.SensorId == sensorId)
            .OrderByDescending(a => a.DataHora)
            .ToList();

        return _mapper.Map<List<AlertaResponse>>(alertas);
    }

    public void DispararManual(ManualAlertaRequest dto)
    {
        DispararAlerta(dto.SensorDataId, dto.Mensagem, "MANUAL");
    }
}

