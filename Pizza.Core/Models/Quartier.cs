using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pizza.Core.Models
{
    public class Quartier
    {
        public Quartier()
        {
            Livreurs = new Collection<Livreur>();
            Livraisons = new Collection<Livraison>();
            Adresses = new Collection<Adresses>();
        }

        public int Id { get; set; }
        public string Nom_Quartier { get; set; }

        public ICollection<Livreur> Livreurs { get; set; }
        public ICollection<Livraison> Livraisons { get; set; }
        public ICollection<Adresses> Adresses { get; set; }
    }
}
