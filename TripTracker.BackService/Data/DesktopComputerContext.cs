using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TripTracker.BackService.Models; //REPLACE

namespace TripTracker.BackService.Data //REPLACE
{
    public class DesktopComputerContext: DbContext
    {
        public DesktopComputerContext(DbContextOptions<DesktopComputerContext> options) : base(options) { }

        public DesktopComputerContext() { }

        public DbSet<DesktopComputer> DesktopComputers { get; set; }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<DesktopComputerContext>();

                context.Database.EnsureCreated();

                if (context.DesktopComputers.Any()) return;

                context.DesktopComputers.AddRange
                (
                    new DesktopComputer[]
                    {
                        new DesktopComputer
                        {
                            Id = 0,
                            Manufacturer = "None",
                            ModelNumber = "0000000",
                            TradeName = "None",
                            ServieTag = "0000",
                            ComputerName ="HEALTH20_1",
                            CameronCountyNumber ="NONE",
                            Department = "Puplic Health",
                            DepartmentProgram = "IT",
                            OperatingSystem = "None",
                            Specifications ="NONE",
                            Notes = "None",
                            DatePurchased = new DateTime(2018, 3, 2),
                            DateDestroyed = new DateTime(2018, 3, 27)
                        }


                    }
                ); ;

                context.SaveChanges();
            }
        } 
    }
}
