using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pizza.Core.Models
{
    public class Client
    {
        public Client()
        {
            CdeClients = new Collection<CdeCli>();
            Factures = new Collection<Fact_Cli_BonLiv>();
        }

        public int Id { get; set; }
        public string Nom_Cli { get; set; }
        public int Num_Adresse { get; set; }

        public Adresses Adresse { get; set; }
        public ICollection<CdeCli> CdeClients { get; set; }
        public ICollection<Fact_Cli_BonLiv> Factures { get; set; }
    }
}
