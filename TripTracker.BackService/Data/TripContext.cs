using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TripTracker.BackService.Models;

namespace TripTracker.BackService.Data
{
    public class TripContext : DbContext
    {

        public TripContext(DbContextOptions<TripContext> options) : base(options) { }

        public TripContext() { }

                     
        public DbSet<Trip> Trips { get; set; }




        //REMOVED BY TUTORIAL 
        /*       
           
                 public TripContext()
                {
                    ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                }
                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Trip>().HasKey(t => t.Id);
                }*/

        public static void SeedData(IServiceProvider serviceProvider)
        {
            //USING STATMENT CREATS AND DESTROYS AFTER COMPLETE
            using (var serviceScope = serviceProvider
                .GetRequiredService<IServiceScopeFactory>().CreateScope())

            {
                var context = serviceScope.ServiceProvider.GetService<TripContext>();

                
                context.Database.EnsureCreated();

                if (context.Trips.Any()) return;

                context.Trips.AddRange
                (
                    new Trip[]
                    {
                        new Trip
                        {
                            Id = 1,
                            Name = "MVP Summit",
                            StartDate = new DateTime(2018, 3, 5),
                            EndDate = new DateTime(2018, 3, 8)

                        },

                        new Trip
                        {
                            Id = 2,
                            Name = "DevIntersection Orlondo 2018",
                            StartDate = new DateTime(2018, 3, 2),
                            EndDate = new DateTime(2018, 3, 27)
                        },

                        new Trip
                        {
                            Id = 3,
                            Name = "Build 2018",
                            StartDate = new DateTime(2018, 5, 7),
                            EndDate = new DateTime(2018, 5, 9)
                        },

                        new Trip
                        {
                            Id = 4,
                            Name = "Second to Last Trip",
                            StartDate = new DateTime(2018, 5, 7),
                            EndDate = new DateTime(2018, 5, 9)
                        },

                        new Trip
                        {
                            Id = 5,
                            Name = "Last Trip",
                            StartDate = new DateTime(2018, 5, 7),
                            EndDate = new DateTime(2018, 5, 9)
                        }

                    }
                ); ;

                context.SaveChanges();
            }
        }
    }
}
