using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Core.Models
{
    public class Ligne_Cde_Cli
    {
        public int Id { get; set; }
        public int Num_Cde_Cli { get; set; }
        public int Num_Pizza { get; set; }
        public string Quantité { get; set; }

        public CdeCli Commande { get; set; }
        public Catalogue_Pizza Pizza { get; set; }
    }
}
