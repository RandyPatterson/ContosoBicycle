using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoBicycle.Models
{
    public class HealthCheckViewModel
    {
        public string HostName { get; set; }
        public IEnumerable<string> Data { get; set; }

        public string  Error { get; set; }
    }
}