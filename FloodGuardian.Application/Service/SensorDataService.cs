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

public class SensorDataService

{

    private readonly FloodGuardianContext _context;
    private readonly PredictionService _predictionService;
    private readonly AlertaService _alertaService;
    private readonly IMapper _mapper;

    public SensorDataService(FloodGuardianContext context, PredictionService predictionService, AlertaService alertaService, IMapper mapper)
    {
        _context = context;
        _predictionService = predictionService;
        _alertaService = alertaService;
        _mapper = mapper;
    }

    public async Task ProcessarDadosAsync(SensorDataRequest dto)
    {
        var entity = _mapper.Map<SensorData>(dto);
        entity.TimeStamp = DateTime.UtcNow;

        _context.Sensor.Add(entity);
        await _context.SaveChangesAsync();

        if (_predictionService.VerificarRisco(entity))
        {
            var mensagem = _predictionService.GerarAlerta(entity);
            _alertaService.DispararAlerta(entity.Id, mensagem, "AUTOMATICO");
        }
    }

    public List<SensorDataResponse> BuscarHistorico(string sensorId)
    {
        var dados = _context.Sensor
            .Where(s => s.SensorId == sensorId)
            .OrderByDescending(s => s.TimeStamp)
            .ToList();

        return _mapper.Map<List<SensorDataResponse>>(dados);
    }

    public List<SensorDataResponse> BuscarUltimosDados()
    {
        var ultimos = _context.Sensor
            .GroupBy(s => s.SensorId)
            .Select(g => g.OrderByDescending(s => s.TimeStamp).First())
            .ToList();

        return _mapper.Map<List<SensorDataResponse>>(ultimos);
    }

    public string GetStatusSensor(string sensorId)
    {
        var ultimo = _context.Sensor
            .Where(s => s.SensorId == sensorId)
            .OrderByDescending(s => s.TimeStamp)
            .FirstOrDefault();

        if (ultimo == null) return "DESCONHECIDO";

        return _predictionService.VerificarRisco(ultimo) ? "RISCO" : "NORMAL";
    }

    public List<SensorDataResponse> BuscarPorPeriodo(string sensorId, DateTime inicio, DateTime fim)
    {
        var dados = _context.Sensor
            .Where(s => s.SensorId == sensorId && s.TimeStamp >= inicio && s.TimeStamp <= fim)
            .OrderByDescending(s => s.TimeStamp)
            .ToList();

        return _mapper.Map<List<SensorDataResponse>>(dados);
    }

}


