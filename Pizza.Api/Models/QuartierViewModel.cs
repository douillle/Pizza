using System.ComponentModel.DataAnnotations;

namespace Pizza.Api.Models
{
    public class QuartierViewModel 
    {
        public int Id { get; set; }

        [Display(Name = "Quartier")]
        public string Nom_Quartier { get; set; }
    }
}
