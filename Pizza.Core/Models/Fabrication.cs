using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Core.Models
{
    public class Fabrication
    {
        public int Id { get; set; }
        public int Num_Pizza { get; set; }
        public int Quant_Fab { get; set; }
        public DateTime Date_Fab { get; set; }

        public Catalogue_Pizza Pizza { get; set; }
    }
}
