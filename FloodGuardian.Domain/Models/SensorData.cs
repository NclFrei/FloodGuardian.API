using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGuardian.Domain.Models;

public class SensorData
{
    public Guid Id { get; set; }
    public string SensorId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double NivelAgua { get; set; }
    public double Umidade { get; set; }
    public double Bateria { get; set; }
    public DateTime TimeStamp { get; set; }
}
