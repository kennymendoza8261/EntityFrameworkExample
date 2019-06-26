using EntityFrameworkExample.Data.Context;
using EntityFrameworkExample.Models;
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

        public List<Barrel> GetAllBarrels()
        {
            return dbCOntext.Barrels.ToList();
        }

        public void Delete(Barrel toDelete)
        {
            dbCOntext.Barrels.Remove(toDelete);
            dbCOntext.SaveChanges();
        }

        public void Add(Barrel toAdd)
        {
            dbCOntext.Barrels.Add(toAdd);
            dbCOntext.SaveChanges();
        }
    }
}