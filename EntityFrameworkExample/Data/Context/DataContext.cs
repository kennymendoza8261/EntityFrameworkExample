using EntityFrameworkExample.Data.Configurations;
using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Data.Context
{
    public class DataContext : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Tell the context about the configurations
            modelBuilder.Configurations.Add(new ExampleEntityConfiguration());
            modelBuilder.Configurations.Add(new ExampleChildEntityConfiguration());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BarrelConfiguration());
            modelBuilder.Configurations.Add(new CubeConfiguration());
        }
        public DbSet<Barrel> Barrels { get; set; }
        public DbSet<Cube> Cubes { get; set; }
    }
}