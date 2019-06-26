using EntityFrameworkExample.Data.Context;
using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Repository
{
    public class CubeRepository
    {
        private DataContext dbContext;
        public CubeRepository()
        {
            dbContext = new DataContext();
        }
        
        public List<Cube> GetAllCubes()
        {
            return dbContext.Cubes.ToList();
        }


        public Cube GetCubeById(int Id)
        {
            return dbContext.Cubes.Find(Id);
        }

        public void Delete(Cube toDelete)
        {
            dbContext.Cubes.Remove(toDelete);
            dbContext.SaveChanges();
        }

        public void Add(Cube toAdd)
        {
            dbContext.Cubes.Add(toAdd);
            dbContext.SaveChanges();
        }

        public void Edit(Cube toEdit)
        {
            dbContext.Entry(toEdit).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}