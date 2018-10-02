using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication6.Models.Model
{
    public class KongsbergEFDemoDbContext : DbContext
    {
        public KongsbergEFDemoDbContext()
            :base("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=KongsbergEFDemo;"
                 +@"Data Source=INBEN10252\SQLEXPRESS;MultipleActiveResultSets=True")
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { //modelBuilder creates a policy for cascade deleting (deleteing states should delete the cities too)
            modelBuilder.Entity<Country>()
                .HasMany(e => e.States)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);  //if not written next set of events wont run
            //this is defined in the base class, and execute its implementation
            //databs
        }
    }
}