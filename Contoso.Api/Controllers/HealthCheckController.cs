﻿using Contoso.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Web.Http;

namespace Contoso.Api.Controllers
{
    public class HealthCheckController : ApiController
    {
        private AnimalContext db = new AnimalContext();
        // GET: api/HealthCheck
        public IHealthCheckModel Get()
        {
            List<string> data = new List<string>();
            var model = new HealthCheckModel { Data = data, HostName = GetLocalIPAddress() };
            try
            {
                data.AddRange(db.Animals.Select(r => r.DisplayName).ToArray());
            }
            catch (Exception e)
            {
                model.Error = e.Message;
            }

            return model;
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "Unknown";
        }
    }
}
