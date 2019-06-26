using EntityFrameworkExample.Models;
using EntityFrameworkExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Services
{
    public class CubeService
    {
        private CubeRepository repository;

        public CubeService()
        {
            repository = new CubeRepository();
        }

        public List<Cube> GetAllCubes()
        {
            return repository.GetAllCubes();
        }

        public void AddCube(Cube c)
        {
            repository.Add(c);
        }

        public Cube GetBarrelById(int Id)
        {
            return repository.GetCubeById(Id);
        }

        public void Delete(Cube c)
        {
            repository.Delete(c);
        }

        public void Edit(Cube toEdit)
        {
            repository.Edit(toEdit);
        }
    }
}