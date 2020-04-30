using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pizza.Core.Models
{
    public class Adresses
    {
        public Adresses()
        {
            Clients = new Collection<Client>();
            Detail_Livs = new Collection<Detail_Liv>();
        }

        public int Id { get; set; }
        public string Adresse { get; set; }
        public int Num_Quartier { get; set; }

        public Quartier Quartier { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Detail_Liv> Detail_Livs { get; set; }
    }
}
