using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Data.Configurations
{
    public class BarrelConfiguration : EntityTypeConfiguration<Barrel>
    {

        public BarrelConfiguration()
        {
            HasKey(b=>b.Id);
        }

    }
}