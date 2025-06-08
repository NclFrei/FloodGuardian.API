using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGuardian.Domain.Dtos.Response;

public class SensorDataResponse
{
    public Guid Id { get; set; }
    public string SensorId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double NivelAgua { get; set; }
    public DateTime Timestamp { get; set; }
    public string Status { get; set; }

}