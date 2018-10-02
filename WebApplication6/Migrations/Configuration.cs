namespace WebApplication6.Migrations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication6.Models;
    using WebApplication6.Models.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication6.Models.Model.KongsbergEFDemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;   //enforcing that migrations are not automatic
        }

        protected override void Seed(WebApplication6.Models.Model.KongsbergEFDemoDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            IList<Country> countries = new List<Country>
            {
                new Country {CountryId=1, CountryName="India"},
                new Country{CountryId=2, CountryName="United States of America"}
            };
            context.Countries.AddOrUpdate(countries.ToArray());

            IList<State> states = new List<State>
            {
                new State{StateId=1, CountryId=1, StateName="Karnataka"},
                new State{StateId=2,CountryId=1, StateName="Andhra Pradesh"},
                new State{StateId=3,CountryId=1, StateName="Tamil Nadu"},
                new State{StateId=4,CountryId=2, StateName="New York"},
                new State{StateId=5,CountryId=2, StateName="California"},
                new State{StateId=6,CountryId=1, StateName="Kerala"}               

            };
            context.States.AddOrUpdate(states.ToArray());

            IList<City> cities = new List<City>
            {
                new City{CityId=1, StateId=1, CityName="Bangalore"},
                new City{CityId=2, StateId=1, CityName="Mysore"},
                new City{CityId=3, StateId=3, CityName="Chennai"},
                new City{CityId=4, StateId=6, CityName="Coimbatore"},
                new City{CityId=5, StateId=2, CityName="Anantapur"},
                new City{CityId=6, StateId=4, CityName="Boston"},
            };
            context.Cities.AddOrUpdate(cities.ToArray());

            base.Seed(context);
        }
    }
}
