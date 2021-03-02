using System.Collections.Generic;

namespace Contoso.Api.Models
{
    public interface IHealthCheckModel
    {
        IEnumerable<string> Data { get; set; }
        string HostName { get; set; }
    }
}