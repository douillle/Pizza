using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pizza.Core.Models
{
    public class BonLiv
    {
        public BonLiv()
        {
            Detail_Livs = new Collection<Detail_Liv>();
        }

        public int Id { get; set; }
        public int Num_Cde_Cli { get; set; }
        public DateTime Date_Liv { get; set; }
        public int? Num_Fact { get; set; }

        public CdeCli CdeCli { get; set; }
        public Fact_Cli_BonLiv Facturation { get; set; }
        public ICollection<Detail_Liv> Detail_Livs { get; set; }
    }
}
