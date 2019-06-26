using EntityFrameworkExample.Data.Context;
using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Barrel GetBarrelById(int Id)
        {
            return dbCOntext.Barrels.Find(Id);
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

        public void Edit(Barrel toEdit)
        {
            dbCOntext.Entry(toEdit).State = System.Data.Entity.EntityState.Modified;
            dbCOntext.SaveChanges();
        }
    }
}