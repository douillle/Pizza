using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pizza.Core.Models
{
    public class CdeCli
    {
        public CdeCli()
        {
            Ligne_Commandes = new Collection<Ligne_Cde_Cli>();
            BonLivs = new Collection<BonLiv>();
        }

        public int Id { get; set; }
        public int Num_Cli { get; set; }
        /// <summary>
        /// 0 - Livré / 1 - A emporter
        /// </summary>
        public bool Livre_Emporte { get; set; }
        public DateTime Date_Cde { get; set; }

        public Client Client { get; set; }
        public ICollection<Ligne_Cde_Cli> Ligne_Commandes { get; set; }
        public ICollection<BonLiv> BonLivs { get; set; }
    }
}
