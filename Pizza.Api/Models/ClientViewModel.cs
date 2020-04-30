using System.ComponentModel.DataAnnotations;

namespace Pizza.Api.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nom")]
        public string Nom_Cli { get; set; }

        public AdresseViewModel Adresse { get; set; }
    }
}
