using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso.Api.Models
{
    public class HealthCheckModel : IHealthCheckModel
    {
        public string HostName { get; set; }
        public IEnumerable<string> Data { get; set; }

    }
}