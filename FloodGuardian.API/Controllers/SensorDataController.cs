using FloodGuardian.Application.Service;
using FloodGuardian.Domain.Dtos.Request;
using FloodGuardian.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FloodGuardian.API.Controllers;

[ApiController]
[Route("api/sensores")]
public class SensorDataController : ControllerBase
{
    private readonly SensorDataService _sensorService;

    public SensorDataController(SensorDataService sensorService)
    {
        _sensorService = sensorService;
    }

    // POST /api/sensores
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SensorDataRequest dto)
    {
        await _sensorService.ProcessarDadosAsync(dto);
        return Ok("Dados processados com sucesso.");
    }

    // GET /api/sensores/{sensorId}/historico
    [HttpGet("{sensorId}/historico")]
    public IActionResult GetHistorico(string sensorId)
    {
        var dados = _sensorService.BuscarHistorico(sensorId);
        return Ok(dados);
    }

    // GET /api/sensores/{sensorId}/status
    [HttpGet("{sensorId}/status")]
    public IActionResult GetStatus(string sensorId)
    {
        var status = _sensorService.GetStatusSensor(sensorId);
        return Ok(new { status });
    }

    // GET /api/sensores/{sensorId}/periodo?inicio=2025-06-01&fim=2025-06-02
    [HttpGet("{sensorId}/periodo")]
    public IActionResult GetPeriodo(string sensorId, [FromQuery] DateTime inicio, [FromQuery] DateTime fim)
    {
        var dados = _sensorService.BuscarPorPeriodo(sensorId, inicio, fim);
        return Ok(dados);
    }

    // GET /api/sensores/ultimos
    [HttpGet("ultimos")]
    public IActionResult GetUltimos()
    {
        var dados = _sensorService.BuscarUltimosDados();
        return Ok(dados);
    }
}