using EntityFrameworkExample.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Repository
{
    public class BarrelRepository
    {
        private DataContext dbCOntext;
        public BarrelRepository()
        {
            dbCOntext = new DataContext();
        }
    }
}