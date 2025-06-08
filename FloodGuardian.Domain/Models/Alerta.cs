using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGuardian.Domain.Models;

public class Alerta
{
    public Guid Id { get; set; }
    public string Mensagem { get; set; }
    public DateTime DataHora { get; set; }
    public string Tipo { get; set; } 
    public Guid SensorDataId { get; set; }
    public string SensorId { get; set; }
    public SensorData SensorData { get; set; }
}
