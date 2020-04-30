using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Core.Models
{
    public class Paiement_Cli
    {
        public int Id { get; set; }
        public int Num_Fact { get; set; }
        public DateTime Date_Payment { get; set; }
        public int Montant_Payment { get; set; }
        
        public Fact_Cli_BonLiv Facturation { get; set; }
    }
}
