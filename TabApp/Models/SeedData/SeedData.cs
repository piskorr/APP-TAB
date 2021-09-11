using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TabApp.Enums;

namespace TabApp.Models.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new dbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<dbContext>>()))
            {
                // Look for any movies.
                if (context.RepairStatus.Any())
                {
                    return;   // DB has been seeded
                }

                context.RepairStatus.AddRange(
                    new RepairStatus
                    {
                        Status = RepairStatuses.Accepted
                    },

                    new RepairStatus
                    {
                        Status = RepairStatuses.InProgress
                    },
                    new RepairStatus
                    {
                        Status = RepairStatuses.Ready
                    },
                    new RepairStatus
                    {
                        Status = RepairStatuses.Issued
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
