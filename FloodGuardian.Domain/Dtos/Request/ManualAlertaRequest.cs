using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGuardian.Domain.Dtos.Request;

public class ManualAlertaRequest
{
    public Guid SensorDataId { get; set; }
    public string Mensagem { get; set; }
}
