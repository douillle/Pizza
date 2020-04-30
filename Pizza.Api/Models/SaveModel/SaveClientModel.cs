using System.ComponentModel.DataAnnotations;

namespace Pizza.Api.Models.SaveModel
{
    public class SaveClientModel
    {
        [Display(Name = "Nom")]
        public string Nom_Cli { get; set; }

        public int Num_Adresse { get; set; }

        public string Adresse { get; set; }

        [Display(Name = "Quartier")]
        public int Num_Quartier { get; set; }
    }
}
