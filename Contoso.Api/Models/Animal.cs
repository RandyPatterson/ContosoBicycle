using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso.Api.Models
{
    public class Animal
    {
        public int id { get; set; }
        public string DisplayName { get; set; }

        public bool IsDomesticated { get; set; }

    }
}