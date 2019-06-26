using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkExample.Models
{
    public class Cube
    {
        [Key]
        public int Id { get; set; }
        public double SideLength { get; set; }
        public double Weight { get; set; }
        public string ConstructionMaterial { get; set; }
        public string Contents { get; set; }
        public string CurrentLocation { get; set; }
        public DateTime DateCreated { get; set; }
    }
}