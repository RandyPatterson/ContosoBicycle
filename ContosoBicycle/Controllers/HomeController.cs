using ContosoBicycle.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ContosoBicycle.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.LocalIp = GetLocalIPAddress();
            HealthCheckViewModel model;
            var uri = WebConfigurationManager.AppSettings["APIURL"];
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    model = JsonConvert.DeserializeObject<HealthCheckViewModel>(await httpClient.GetStringAsync(uri));
                } 
                catch (Exception e)
                {
                    model = new HealthCheckViewModel
                    {
                        Error = e.Message
                    };
                }
            }

            if (model.Data == null)
                model.Data = new List<string>();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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