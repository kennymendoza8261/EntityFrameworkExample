using EntityFrameworkExample.Models;
using EntityFrameworkExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Services
{
    public class BarrelService
    {
        private BarrelRepository repo;
        public BarrelService()
        {
            repo = new BarrelRepository();
        }

        public List<Barrel> GetAllBarrels()
        {
            return repo.GetAllBarrels();
        }

        public void AddBarrel(Barrel b)
        {
            repo.Add(b);
        }

       /* public Barrel Search(int id)
        {
            List<Barrel> BarrelSearch;
            BarrelSearch = repo.GetAllBarrels();
            foreach(Barrel barrel in BarrelSearch)
            {
                if(barrel.)
            }
        }
        */
        public Barrel GetBarrelById(int Id)
        {
            return repo.GetBarrelById(Id);
        }

        public void Delete(Barrel b)
        {
            repo.Delete(b);
        }

        public void Edit(Barrel toEdit)
        {
            repo.Edit(toEdit);
        }
    }
}