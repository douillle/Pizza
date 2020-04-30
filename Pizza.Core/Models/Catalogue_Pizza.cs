using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pizza.Core.Models
{
    public class Catalogue_Pizza
    {
        public Catalogue_Pizza()
        {
            Ligne_Commandes = new Collection<Ligne_Cde_Cli>();
            Fabrications = new Collection<Fabrication>();
        }

        public int Id { get; set; }
        public string Nom_Pizza { get; set; }
        /// <summary>
        /// 0 - Medium / 1 - Large 
        /// </summary>
        public bool Taille_Pizza { get; set; }
        public int Prix_Pizza { get; set; }

        public ICollection<Ligne_Cde_Cli> Ligne_Commandes { get; set; }
        public ICollection<Fabrication> Fabrications { get; set; }
    }
}
