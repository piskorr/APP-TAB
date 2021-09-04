using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;

    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<TabApp.Models.Person> Person { get; set; }

        public DbSet<TabApp.Models.Item> Item { get; set; }

        public DbSet<TabApp.Models.Worker> Worker { get; set; }
    }
