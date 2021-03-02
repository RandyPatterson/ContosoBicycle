using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso.Api.Models
{
    public class AnimalInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AnimalContext>
    {

        protected override void Seed(AnimalContext context)
        {
            var animals = new List<Animal>
            {
                new Animal { DisplayName = "Dog", IsDomesticated=true },
                new Animal { DisplayName = "Cat", IsDomesticated = true },
                new Animal { DisplayName = "Lion", IsDomesticated = false },
                new Animal { DisplayName = "Tiger", IsDomesticated = false },
                new Animal { DisplayName = "Bear", IsDomesticated = false }

            };
            context.Animals.AddRange(animals);
            context.SaveChanges();


        }
    }
}