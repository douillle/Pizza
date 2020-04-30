using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pizza.Core.Models
{
    public class Livraison
    {
        public Livraison()
        {
            Detail_Livs = new Collection<Detail_Liv>();
        }

        public int Id { get; set; }
        public DateTime Date_Depart { get; set; }
        public DateTime Date_Arrive { get; set; }
        public int Num_Quartier { get; set; }
        public Quartier Quartier { get; set; }

        public ICollection<Detail_Liv> Detail_Livs { get; set; }
    }
}
