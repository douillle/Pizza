using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pizza.Core.Models
{
    public class Fact_Cli_BonLiv
    {
        public Fact_Cli_BonLiv()
        {
            BonLivs = new Collection<BonLiv>();
            Payments = new Collection<Paiement_Cli>();
        }

        public int Id { get; set; }
        public DateTime Date_Fact_Cli { get; set; }
        public int Montant_Total { get; set; }
        public int Num_Cli { get; set; }

        public Client Client { get; set; }
        public ICollection<BonLiv> BonLivs { get; set; }
        public ICollection<Paiement_Cli> Payments { get; set; }
    }
}
