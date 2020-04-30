using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Core.Models
{
    public class Detail_Liv
    {
        public int Id { get; set; }
        public int? Num_Bon_Liv { get; set; }
        public int? Num_Liv { get; set; }
        public int Num_Adresse { get; set; }

        public Adresses Adresse { get; set; }
        public BonLiv BonLiv { get; set; }
        public Livraison Livraison { get; set; }
    }
}
