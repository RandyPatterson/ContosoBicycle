using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contoso.Api.Models
{
    public class AnimalContext: DbContext 
    {
        public AnimalContext() : base("AnimalContext")
        {

        }

        public DbSet<Animal> Animals { get; set; }


    }
}