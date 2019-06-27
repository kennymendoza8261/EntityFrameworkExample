using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Models
{
    public class BarrelCount
    {
        public double Radius { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string ConstructionMaterial { get; set; }
        public string Contents { get; set; }
        public string CurrentLocation { get; set; }
        public DateTime DateCreated { get; set; }
        public int Amount { get; set; }
    }
}