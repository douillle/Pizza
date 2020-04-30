using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Api.Models
{
    public class AdresseViewModel
    {
        public int Id { get; set; }
        public string Adresse { get; set; }
        public QuartierViewModel Quartier { get; set; }
    }
}
