using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MsBase.Data;

namespace MsBase.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MsBaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MsBaseContext>>()))
            {
                // Look for any movies.
                if (context.MsBaseModel.Any())
                {
                    return;   // DB has been seeded
                }

                context.MsBaseModel.AddRange(
                    new MsBaseModel
                    {
                        Name = "Tires",
                        Country = "Poland",
                        Avilable = true,
                        Price = 7.99M,
                    },

                    new MsBaseModel
                    {
                        Name = "Screws",
                        Country = "Brasil",
                        Avilable = false,
                        Price = 7.99M,
                    },

                    new MsBaseModel
                    {
                        Name = "Hubcap",
                        Country = "Germany",
                        Avilable = true,
                        Price = 7.99M,
                    },

                    new MsBaseModel
                    {
                        Name = "Car windshield",
                        Country = "Poland",
                        Avilable = false,
                        Price = 7.99M,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
