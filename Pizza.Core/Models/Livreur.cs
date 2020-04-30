using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Core.Models
{
    public class Livreur
    {
        public int Id { get; set; }
        public string Nom_Livreur { get; set; }
        public int Num_Quartier { get; set; }
        public Quartier Quartier { get; set; }
    }
}
