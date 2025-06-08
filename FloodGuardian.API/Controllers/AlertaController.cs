using FloodGuardian.Application.Service;
using FloodGuardian.Domain.Dtos.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FloodGuardian.API.Controllers;

[ApiController]
[Route("api/alertas")]
public class AlertaController : ControllerBase
{
    private readonly AlertaService _alertaService;

    public AlertaController(AlertaService alertaService)
    {
        _alertaService = alertaService;
    }

    // GET /api/alertas/recentes
    [HttpGet("recentes")]
    public IActionResult GetRecentes([FromQuery] int qtd = 10)
    {
        var alertas = _alertaService.ListarAlertasRecentes(qtd);
        return Ok(alertas);
    }

    // GET /api/alertas/sensor/{sensorId}
    [HttpGet("sensor/{sensorId}")]
    public IActionResult GetPorSensor(string sensorId)
    {
        var alertas = _alertaService.BuscarPorSensor(sensorId);
        return Ok(alertas);
    }

    // POST /api/alertas/manual
    [HttpPost("manual")]
    public IActionResult DispararManual([FromBody] ManualAlertaRequest dto)
    {
        _alertaService.DispararManual(dto);
        return Ok("Alerta manual disparado.");
    }
}
