using FloodGuardian.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGuardian.Application.Service;

public class PredictionService
{
    private const double LIMITE_ENCHENTE = 2.5;

    public bool VerificarRisco(SensorData data)
    {
        return data.NivelAgua >= LIMITE_ENCHENTE;
    }

    public string GerarAlerta(SensorData data)
    {
        return $"⚠️ Alerta de enchente! Sensor: {data.SensorId} | Nível: {data.NivelAgua}m às {data.TimeStamp:HH:mm}";
    }
}
